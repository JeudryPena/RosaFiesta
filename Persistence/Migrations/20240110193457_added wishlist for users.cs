using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedwishlistforusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c696e428-4bc8-4be2-bbf4-94812e9d043c", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5556), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPRmtNYJJlhH5p4kgaXdR+P3cj2b59ielbzX00FRlq5zhJrb2mUxjnUkHR+3JBiSQQ==", "a5767903-116f-4d00-ab90-0b7eb3423085" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9944059-e657-4ed3-a5af-dc0437df1bd4", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5572), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEG6IoZV/iHv8meKeuqNGnWJfHJx3kdsT/j+jZe28LlH9BMQMas0aznX5nP6ljbMeCQ==", "b7a787b0-5487-46f1-81b3-642f1bfc112b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c310ca3-1e03-4901-b461-a0b5149d5369", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENK1JmBXxvFknzXyyfSsojeqKUT8hwk/3Xxt3U6LBDeCz4P27k8yuVCDAEwKMzMYIQ==", "c6828521-4392-4975-844f-bc7a3346bee2" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e7164e7-2503-4362-bcac-fa6ba95b4f7e", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5512), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOC+3Q7eE2CaL9ntZd634zjw3X2wyp/HePwmgWoEpKRaqumFcyXfEK/AybgqbUMeVg==", "e5e48797-171a-43f9-bfae-7daf33bf5669" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e216517b-5d65-44c3-a851-3ee2ef2ebb3b", new DateTimeOffset(new DateTime(2024, 1, 10, 15, 34, 55, 996, DateTimeKind.Unspecified).AddTicks(5251), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFJ40EGBpOP4nujMKa/d5Aat47+x4KyBBFf2rlw+HGhg0vuLMgj9i6SAp6gUBlKojQ==", "ccf26d32-82dd-45e4-b9aa-57980bc37eeb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b74af7f-e10a-4f01-8237-9c16e48e4b78", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3929), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIh8L7AeuKuoSgd/LzKVTxt2h0Xv6PsYkOsU/K0OgFS8zjyXeH1lEmCydII9HBdrTA==", "10610b73-6018-49e8-bb7b-e53ee8785b42" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b98318e-504a-4022-a5e4-c0be8ff1f208", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDVk2Bcc1MjKTKq2UfdnSXx5fMWIGlMFWtFwnlnfdCLa7eXicvE3uE+qGiLoy/OoSg==", "2d1b4fd6-2b0a-48fc-bfe0-27f4fc40bd1f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2301d884-221a-4e7d-b509-0113dcc043e3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7db81e4a-bac3-475a-a7d9-f9a7a5b5f0d7", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3976), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEJsnChgsN4Kc0ycEsOLuwDl7B2um+H650yDGnlsU9Fk3jfeu5D8u1WV587i1fz9KMg==", "e770956a-5597-4a8c-a147-d70da862ee68" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7d9b7113-a8f8-4035-99a7-a20dd400f6a3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be950c5b-cfba-4c88-a9dc-4cffcbec6d40", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3895), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEM39W5TJ7zLfGQKH9oMaG3WQcCtu3WUwLgXRGxS8Bdm8FubzB6xzpNKDrV/OJJK8Sg==", "840b3ec4-0d70-4829-8e3f-12511fc4f2df" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "Users",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f9c3a29-5348-4964-9d04-b19d23a1bca2", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 27, 7, 815, DateTimeKind.Unspecified).AddTicks(3690), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBSva7yT2S3a4LVZbfq5LRXHwHDSEju+Mo7uSzXdTpWKGMKcJBwKmBAUkkxv17354g==", "94c7258d-94c1-4a4c-8527-4ad46fb2c224" });
        }
    }
}
