using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67325824-f93a-4801-90e0-9e61c41fb2d3", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 26, 10, 379, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHwDK4zHycuAaZreyjyKDck3JE4iqmOJh4SZXBCkfp00QE+LsrwX62Um69UwgqzjHw==", "07abf466-da8d-4a70-878c-6dcbf026b31b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9542383c-a6a0-49ec-91ba-bfbee8f01eb3", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 26, 10, 379, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKLkx4uM6mNmnReWDBwbTMKEWGKz3Gcdho/7wJLIG1wO7J8UbYmSRNcaTjldceHeFQ==", "45ee3301-e3f2-4ddb-a575-028f6b79397f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19f621f2-8094-4b7e-ac81-75ede9c588f6", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 26, 10, 379, DateTimeKind.Unspecified).AddTicks(2202), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHudqGt2LbyEHE1TQh0/uFJxsVVeofzrPS0Ag6Cso3SbOXplTReJbZLWxT8VyTimgg==", "327832c3-40f1-47c1-9bec-8f3b301b0383" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47048236-5910-4c75-a57f-8a39a7e66049", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 26, 10, 379, DateTimeKind.Unspecified).AddTicks(2062), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEMU7ebIFdC3FgIaqiUlQYhEssf5AV7BlYcjlmsS1n8jtQMXEMhdHlG2f7eP4//qHGA==", "63e402de-5592-4135-9712-bb65c9964004" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dec660c5-b620-4e17-9e3a-cba8a2e1b736", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 26, 10, 379, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEHnFrgjHNEQ2Fq0kHrz3w9xuQh+a9cpTA8C9OOdzwQjdkQ9GucxvLJZFJM+4x5KvSA==", "c9fb7484-74a5-497c-af45-39ab17149554" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed83a00f-b087-403a-8398-b08ccdf7610e", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 21, 6, 627, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEBwXi7mO85leCuFQ+kGwepBlbtXYI4a1eCYi4E0eqKAjJP7FFnIJNAcv2m/ACKpVxA==", "8f7a9dfd-b779-4fe5-810d-bf84e30eb8d8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35d9ec2d-4b0b-4328-abbe-cbff1b935060", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 21, 6, 627, DateTimeKind.Unspecified).AddTicks(5016), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFFnzlNiz237ARlJmzeFyZMTwQhmTDbREZUIxI83HIxOQj5nQD+Q/Hcku9+KDPtttA==", "f12f3dd1-7c3e-41e6-8e3b-c69a956e787e" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f9d88ff-77ee-49f9-b78d-43bdbd85f34c", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 21, 6, 627, DateTimeKind.Unspecified).AddTicks(5026), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEOsQjwIk9ZwTpmKL5kKo/YCXbJzsnPXLUbZzmG2tOKBglZQA4tZRIrqys0RKi1JrTg==", "9b33bdd8-16eb-427a-a89a-7cc58959e96f" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb59f78c-5100-4abb-ac80-d697f1516ffb", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 21, 6, 627, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECHp9TCEbNpYJxhJ4m4VqBFGVRpybXwK/cdAtO0fQsjimbTUbgQkaTFKs4ioCNl4wA==", "223bc04a-ab98-4366-bf83-a5458265255b" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb675563-475f-4fc1-b526-a3f6a8ce46fa", new DateTimeOffset(new DateTime(2023, 6, 27, 22, 21, 6, 627, DateTimeKind.Unspecified).AddTicks(4800), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEDc5+dONH3kqPBwmLsXHf5z+G6M1r/OClgc2TbHHglPO+KoOf/k8FCWHjfO7iVGbgg==", "690a5e03-7882-4a95-bfbf-9a6cc68180c5" });
        }
    }
}
