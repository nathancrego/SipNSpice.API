using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class initialcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088926c1-9cee-4c88-aaf5-62bbed2269e8",
                column: "ConcurrencyStamp",
                value: "c2a9655c-c8bb-42ec-8734-9bab665b643a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6df99e-946a-425a-b312-709296422852",
                column: "ConcurrencyStamp",
                value: "807f2d52-5f24-4b64-a350-261c136bac81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7adc41f5-2dfb-4df9-8d7d-f5a34f3c1c43", "AQAAAAIAAYagAAAAEKntixkuL15LJBX5yzDZb3QkDS2PWCL5CXdWyvI9rAGOtIQ3mjkXccII20MuOtIEmw==", "4bd45a79-fcbe-41dd-8dd3-0c2ce9d8ca78" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088926c1-9cee-4c88-aaf5-62bbed2269e8",
                column: "ConcurrencyStamp",
                value: "46b721d3-356a-43e2-9a6e-62e060c90e34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6df99e-946a-425a-b312-709296422852",
                column: "ConcurrencyStamp",
                value: "3bfc611b-2ba0-45ef-a541-0f3de2d8d174");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25c9162-a3c6-46d5-a626-ab338520d212", "AQAAAAIAAYagAAAAEBxrLSnZNwChCt22CLkdZp+tUz8EPqtfFLzyT0oGDUSG2ooc26nNdkXFA7h7C255Sw==", "43547ecf-22f6-450c-9977-65d84a58bd0f" });
        }
    }
}
