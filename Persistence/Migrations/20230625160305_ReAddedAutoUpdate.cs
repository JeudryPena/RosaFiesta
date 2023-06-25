using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReAddedAutoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "Warranties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "Warranties",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "SupplierEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "ProductEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "ProductEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CreatedBy", "PasswordHash", "SecurityStamp", "UpdatedBy" },
                values: new object[] { "ea844c3c-d03b-4dfe-b144-6cf5298e3758", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, -4, 0, 0, 0)), "", "AQAAAAIAAYagAAAAEKOKSuO5si1r1V2ySEU2cLYhigVlRIjo1R+aVDk7qcUuSPX76NLx6VBYloTwTxOYEg==", "46860ea7-7adb-4da4-9b60-a5e47b248d71", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CreatedBy", "PasswordHash", "SecurityStamp", "UpdatedBy" },
                values: new object[] { "eb6bb3e1-d8e4-48a4-98bf-0c193f318a57", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2137), new TimeSpan(0, -4, 0, 0, 0)), "", "AQAAAAIAAYagAAAAEA5hvS10LjDtXsFoxYjWPG7lA0wiwym3LmUc5DaKL7xI0BhYGaTG9FBqK0VHP2QbFg==", "b02792d0-e8f7-4a1c-a003-dc7ce9bbfe2a", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CreatedBy", "PasswordHash", "SecurityStamp", "UpdatedBy" },
                values: new object[] { "34da0a8b-408f-4d81-833f-bce5b08eb116", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2161), new TimeSpan(0, -4, 0, 0, 0)), "", "AQAAAAIAAYagAAAAENwPz8Pab1ykWEOZrsmJqUgVrHMle/iBLSJ7EwrRtsD4FBkQ0Dme3zH9i5qI4MsjUA==", "abae720e-5e6b-4303-a692-980a484f6b98", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CreatedBy", "PasswordHash", "SecurityStamp", "UpdatedBy" },
                values: new object[] { "f0837626-38fe-4eed-803f-f577f6a20e1d", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, -4, 0, 0, 0)), "", "AQAAAAIAAYagAAAAEPzOuWOqM2h2HNb10uZqyhYj+DZL4dZrLhyWN8KIpBcty1F8vhjStYEXNq0agf0+FQ==", "c6a675b5-6a8e-44cd-94e0-c16fa1c341ec", null });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "CreatedBy", "PasswordHash", "SecurityStamp", "UpdatedBy" },
                values: new object[] { "61fd1bcc-41bb-43b0-aee3-a93664760c1e", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, -4, 0, 0, 0)), "", "AQAAAAIAAYagAAAAEFnwRFxLlF3Lc9RWfuS80Aw8FaeH1EqUha7Egzdrdy//m9ADWURioWOqwuwwGuu7YQ==", "04efd7ef-b1b1-4f22-a8d0-48fe0ca30495", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "Warranties");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "Warranties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "SupplierEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "SupplierEntity");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "ProductEntity");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "RosaFiesta",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "RosaFiesta",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "ProductsDiscountsEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "RosaFiesta",
                table: "Options",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "RosaFiesta",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55c91f19-d48a-46fa-bf74-8c360c0c139f", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1113), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAELI7v8MgP2jdMdxS9qAUooBMUFmE5/77xBocwWko63+z/9kmzOMRMFeIRGHf1i85rA==", "e3748700-f40b-42b7-a140-ffaa0b438306" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d8f8578-79c5-4c66-a258-d190a7884f2b", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1130), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEEqzZ16K3cdb0GH/LhD3FxF4sxTQPu5EHEQd6/h/IsPT2SCHDL7bbkKeeDGiUyUOwQ==", "e9b95cd3-ddbc-4407-8ab4-3fbaba44bf4c" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91f45ea1-8aaa-4cf7-b34a-b447b86f0103", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1151), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECaq08T1SVD0JF2KWjPQQq6zGkioMEWwsaS5jArg9rwWQlQ0qZ0TmWjO1JS4V8Q9rg==", "6a6ad4ac-aafb-4d08-9e79-d7583a778e9a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61f0180d-ee4b-49d8-a433-d8387317044f", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(1091), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEAZgwkeYpj9ACpu1DapdocvJg5zWTODKA8DNTxmuP7FzsKjumnnH3utyUNIo+/cNkw==", "e61a3774-587b-422f-beb1-51813ef9382a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b38b33-5be1-4c16-8942-adc7a5397b9c", new DateTimeOffset(new DateTime(2023, 6, 25, 10, 2, 29, 290, DateTimeKind.Unspecified).AddTicks(790), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECBsNo63LHGLds0S+6JMcYL876Olc54C/XZNlErQUbJgd6baXcluWxwc9ndQzc4+zg==", "dbfbf831-0921-4c94-bc22-7dfda9579356" });
        }
    }
}
