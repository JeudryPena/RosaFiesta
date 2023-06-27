using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

using Domain.Configuration;
using Domain.Entities.Security;
using Domain.IRepository;

using Messaging;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Persistence;
using Persistence.Repository;

using Serilog;

using Services;
using Services.Abstractions;

using WebApi.Middleware;

namespace WebApi;

[ExcludeFromCodeCoverage]
public static class Program
{
	private const string OriginsKey = "Origins";
	private const string SqlConnectionString = "SqlServerConnection";
	private const string PostgresConnectionString = "PostgreConnection";
	private const string JwtTokenConfigKey = "jwtTokenConfig";
	private const string SmtpKey = "EmailConfiguration";

	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		AddControllers(builder);
		AddCompressionMethod(builder);
		AddSwagger(builder);
		AddCors(builder.Services, builder.Configuration);
		AddDbContext(builder.Services, builder.Configuration);
		AddHttpContext(builder.Services);
		AddIdentity(builder.Services, builder.Configuration);
		AddJwtTokenAuthentication(builder.Services, builder.Configuration);
		AddRepository(builder.Services);
		AddService(builder.Services);
		AddFileManage(builder.Services, builder);

		builder.Services.Configure<FormOptions>(o =>
		{
			o.ValueLengthLimit = int.MaxValue;
			o.MultipartBodyLengthLimit = int.MaxValue;
			o.MemoryBufferThreshold = int.MaxValue;
		});
		builder.Services.AddTransient<ExceptionHandlingMiddleware>();
		builder.Services.AddEndpointsApiExplorer();

		var app = builder.Build();

		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
		}
		app.UseStaticFiles();
		app.UseStaticFiles(new StaticFileOptions()
		{
			FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
			RequestPath = new PathString("/Resources")
		});
		app.UseMiddleware<ExceptionHandlingMiddleware>();
		app.UseCors();
		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.UseResponseCompression();
		app.MapControllers();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();
		app.UseEndpoints(endpoints => endpoints.MapControllers());
		using var serviceScope = app.Services.CreateScope();
		using var context = serviceScope.ServiceProvider.GetService<RosaFiestaContext>();
		context.Database.Migrate();


		app.Run();
	}

	private static void AddFileManage(IServiceCollection services, WebApplicationBuilder builder)
	{
		builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
		{
			loggerConf.WriteTo.Console().WriteTo.Debug().ReadFrom.Configuration(hostBuilderCtx.Configuration);
		});

		services.Configure<FormOptions>(o =>
		{
			o.ValueLengthLimit = int.MaxValue;
			o.MultipartBodyLengthLimit = int.MaxValue;
			o.MemoryBufferThreshold = int.MaxValue;
		});
	}


	private static void AddControllers(WebApplicationBuilder builder)
	{
		var emailConfig = builder.Configuration.GetSection(SmtpKey)
			.Get<EmailConfiguration>();
		builder.Services.AddSingleton(emailConfig);

		builder.Services
			.AddControllers()
			.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
		builder.Services
			.AddControllers()
			.AddJsonOptions(opt =>
			{

				opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});
		// Newtonsoft
		builder.Services
			.AddControllers()
			.AddNewtonsoftJson(opts =>
			{
				opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft
					.Json
					.ReferenceLoopHandling
					.Ignore;
				opts.SerializerSettings.NullValueHandling = Newtonsoft
					.Json
					.NullValueHandling
					.Ignore;
				opts.SerializerSettings.DateTimeZoneHandling = Newtonsoft
					.Json
					.DateTimeZoneHandling
					.Local;
				opts.UseCamelCasing(false);
			});
	}

	private static void AddCompressionMethod(WebApplicationBuilder builder)
	{
		builder.Services.AddResponseCompression(opts =>
		{
			opts.Providers.Add<BrotliCompressionProvider>();
			opts.Providers.Add<GzipCompressionProvider>();
		});
		builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
		{
			options.Level = CompressionLevel.Optimal;
		});
		builder.Services.Configure<GzipCompressionProviderOptions>(options =>
		{
			options.Level = CompressionLevel.Optimal;
		});
	}

	private static void AddSwagger(WebApplicationBuilder builder)
	{
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc(
				"v1",
				new OpenApiInfo
				{
					Title = "Rosa Fiesta Module API",
					Version = "v1",
					Description = "Rosa Fiesta Module",
					Contact = new OpenApiContact
					{
						Name = "Rosa Fiesta",
						Email = "rosaFiesta@hotmail.net"
					}
				}
			);

			var securityScheme = new OpenApiSecurityScheme
			{
				Name = "JWT Authentication",
				Description = "Enter JWT Bearer token **_only_**",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = "bearer",
				BearerFormat = "JWT",
				Reference = new OpenApiReference
				{
					Id = "Bearer",
					Type = ReferenceType.SecurityScheme
				}
			};
			c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
			c.AddSecurityRequirement(
				new OpenApiSecurityRequirement { { securityScheme, Array.Empty<string>() } }
			);
		});
	}

	private static void AddCors(IServiceCollection services, ConfigurationManager configuration)
	{
		var origins = configuration.GetSection(OriginsKey).Get<string[]>()!;

		services.AddCors(
			c =>
				c.AddDefaultPolicy(
					builder =>
						builder
							.WithOrigins(origins)
							.AllowAnyMethod()
							.AllowAnyHeader()
							.AllowCredentials()
							.WithExposedHeaders(
								"Content-Disposition",
								"downloadfilename",
								"IsEditable"
							)
				)
		);
	}

	private static void AddDbContext(
		IServiceCollection services,
		ConfigurationManager configuration
	)
	{
		var migrationsAssembly = typeof(RosaFiestaContext).GetTypeInfo().Assembly.GetName().Name;
		string? connectionString = configuration.GetConnectionString(SqlConnectionString);

		string? postgresConnectionString = configuration.GetConnectionString(PostgresConnectionString);

		void PgContextBuilder(DbContextOptionsBuilder b)
		{
			b.UseNpgsql(
				postgresConnectionString,
				npg =>
				{
					npg.MigrationsAssembly(migrationsAssembly);
					npg.MigrationsHistoryTable(
						"_EFRosaFiestaMigrationHistory",
						RosaFiestaContext.DefaultSchema
					);
					npg.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
				}
			);
			b.EnableSensitiveDataLogging();
		};


		/*void ContextBuilder(DbContextOptionsBuilder b) =>
            b.UseSqlServer(
                connectionString,
                sql =>
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                    sql.MigrationsHistoryTable(
                        "_EFNegotiationMigrationHistory",
                        RosaFiestaContext.DefaultSchema
                    );
                    sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                }
            );

        services.AddDbContext<RosaFiestaContext>(ContextBuilder);*/
		services.AddDbContext<RosaFiestaContext>(PgContextBuilder);
		services.AddScoped<DbContext, RosaFiestaContext>();
	}

	private static void AddHttpContext(IServiceCollection builderServices)
	{
		builderServices.AddHttpContextAccessor();
		builderServices.AddHttpClient();
		builderServices.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
	}

	private static void AddIdentity(IServiceCollection services, ConfigurationManager configuration)
	{
		services
			.AddIdentity<UserEntity, IdentityRole>(opts =>
			{
				opts.Password.RequiredLength = 8;
				opts.Password.RequireDigit = true;
				opts.Password.RequiredUniqueChars = 0;
				opts.Password.RequireLowercase = true;
				opts.Password.RequireNonAlphanumeric = true;
				opts.Password.RequireUppercase = true;
				opts.SignIn.RequireConfirmedEmail = true;
				opts.User.RequireUniqueEmail = true;
				opts.Lockout.AllowedForNewUsers = true;
				opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				opts.Lockout.MaxFailedAccessAttempts = 5;
			})
			.AddEntityFrameworkStores<RosaFiestaContext>()
			.AddDefaultTokenProviders();

		services.Configure<DataProtectionTokenProviderOptions>(
			opt => opt.TokenLifespan = TimeSpan.FromHours(2)
		);
	}

	private static void AddJwtTokenAuthentication(
		IServiceCollection services,
		ConfigurationManager configuration
	)
	{
		services
			.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidAudience = configuration["JWT:ValidAudience"],
					ValidIssuer = configuration["JWT:ValidIssuer"],
					ValidateIssuerSigningKey = true,
					RequireExpirationTime = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(configuration["JWT:Secret"])
					),
					ClockSkew = TimeSpan.FromMinutes(5)
				};
			});
	}

	private static void AddRepository(IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}

	private static void AddService(IServiceCollection services)
	{
		services.AddScoped<IServiceManager, ServiceManager>();
		services.AddScoped<IEmailSender, EmailSender>();
	}
}
