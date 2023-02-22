using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Core.Models;
using Core.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;

namespace WebApi;

public static class Program
{
    private const string OriginsKey = "Origins";
    private const string SqlConnectionString = "SqlServerConnection";
    private const string JwtTokenConfigKey = "jwtTokenConfig";
    private const string SmtpKey = "SmtpConfig";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AddControllers(builder);
        AddCompressionMethod(builder);
        AddSwagger(builder);
        AddCors(builder.Services, builder.Configuration);
        AddDbContext(builder.Services, builder.Configuration);
        AddServices(builder.Services);
        AddRepositories(builder.Services);
        AddIdentity(builder.Services, builder.Configuration);
        AddJwtTokenAuthentication(builder.Services, builder.Configuration);

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
        }

        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseResponseCompression();
        app.MapControllers();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // migrate any database changes on startup (includes initial db creation)
        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<RosaFiestaContext>();
            dataContext.Database.Migrate();
        }

        app.Run();
    }

    private static void AddControllers(WebApplicationBuilder builder)
    {
        // Nose que es
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
        // Nose que es
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

            var xmlFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
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

        void ContextBuilder(DbContextOptionsBuilder b) =>
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

        services.AddDbContext<RosaFiestaContext>(ContextBuilder);
        services.AddScoped<DbContext, RosaFiestaContext>();
    }

    private static void AddServices(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    private static void AddIdentity(IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddIdentity<UserEntity, RoleEntity>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireDigit = true;
                opts.Password.RequiredUniqueChars = 0;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireUppercase = true;
                opts.SignIn.RequireConfirmedAccount = true;
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
                    ValidAudience = configuration["jwtTokenConfig:audience"],
                    ValidIssuer = configuration["jwtTokenConfig:issuer"],
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwtTokenConfig:secret"])
                    ),
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
    }
}
