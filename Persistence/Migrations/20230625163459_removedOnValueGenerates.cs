using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removedOnValueGenerates : Migration
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
                values: new object[] { "37339a29-ea4e-4c5f-9741-c7f784a5d642", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6729), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEK5VLGhvsmPCyNCImUmaxwYV1WZ2ZksbCxvzTYVuavqpGiLU7juDbyn4rusbIcq+Rw==", "27af544a-f7c9-4939-92fa-96546cd7a564" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24a03d23-83d5-46ec-95cd-e97133d3f49b", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6739), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFMRaq6OV28QGCLGL/ccfvoJlV5Y14mCe6wOcM8QLTEEfvnlRWTIYUXNU27CmpG25w==", "d910c400-a45a-43cf-97ee-e6f11cfa76d8" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4356958b-e234-4fcf-a704-fce1a1a68d25", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6784), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEIYqECmmIUbmacT9mJDONcqNX+e4xIkU1T73KjFponTBDLrRi7aNUQ/ZfKK7xaOeNw==", "e51b21ec-b0be-4410-987b-a1575eadbfe3" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "729f145b-bd0b-4a7a-9173-e131ffd4bc67", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEB5vlA0x5bHS+p8E6/tsUNKrN+xyfY+gpItzbtlEYoMauBNzJ1aXlSko8JOMIO4ngQ==", "6872fa88-edae-4159-8a87-d2cf9f191f29" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7baa828-fb76-4e9f-9038-3a5976089e5f", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 34, 59, 252, DateTimeKind.Unspecified).AddTicks(6468), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAECpxjs7xhd5O4f/uyCKO+dcTYoYiCH1yoAHZiHfh+5aVZF0+2lKkv8Jt8YHbyH8Dfw==", "6c3b5d5f-66ca-416b-b31a-e3afb9cc1674" });
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
                values: new object[] { "ea844c3c-d03b-4dfe-b144-6cf5298e3758", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEKOKSuO5si1r1V2ySEU2cLYhigVlRIjo1R+aVDk7qcUuSPX76NLx6VBYloTwTxOYEg==", "46860ea7-7adb-4da4-9b60-a5e47b248d71" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb6bb3e1-d8e4-48a4-98bf-0c193f318a57", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2137), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEA5hvS10LjDtXsFoxYjWPG7lA0wiwym3LmUc5DaKL7xI0BhYGaTG9FBqK0VHP2QbFg==", "b02792d0-e8f7-4a1c-a003-dc7ce9bbfe2a" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34da0a8b-408f-4d81-833f-bce5b08eb116", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2161), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAENwPz8Pab1ykWEOZrsmJqUgVrHMle/iBLSJ7EwrRtsD4FBkQ0Dme3zH9i5qI4MsjUA==", "abae720e-5e6b-4303-a692-980a484f6b98" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0837626-38fe-4eed-803f-f577f6a20e1d", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(2065), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEPzOuWOqM2h2HNb10uZqyhYj+DZL4dZrLhyWN8KIpBcty1F8vhjStYEXNq0agf0+FQ==", "c6a675b5-6a8e-44cd-94e0-c16fa1c341ec" });

            migrationBuilder.UpdateData(
                schema: "RosaFiesta",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b22698b8-42a2-4115-9631-1c2d1e2ac5f7",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61fd1bcc-41bb-43b0-aee3-a93664760c1e", new DateTimeOffset(new DateTime(2023, 6, 25, 12, 3, 4, 659, DateTimeKind.Unspecified).AddTicks(1283), new TimeSpan(0, -4, 0, 0, 0)), "AQAAAAIAAYagAAAAEFnwRFxLlF3Lc9RWfuS80Aw8FaeH1EqUha7Egzdrdy//m9ADWURioWOqwuwwGuu7YQ==", "04efd7ef-b1b1-4f22-a8d0-48fe0ca30495" });
        }
    }
}
