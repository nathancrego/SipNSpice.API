using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class initialcreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088926c1-9cee-4c88-aaf5-62bbed2269e8",
                column: "ConcurrencyStamp",
                value: "fdfb916e-4265-4ff5-a8b5-a4de5d4d4d5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6df99e-946a-425a-b312-709296422852",
                column: "ConcurrencyStamp",
                value: "c052b0a4-8907-490e-a3b7-86ea2334510a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5587bc68-9ec8-4d02-ad45-a6ff2bb4fb3f", "AQAAAAIAAYagAAAAEKy6ZZPE50adWICGrVBV/bSlCp0JM0ekYxjPt4zXyYmAji0wYf6qGipViG81jWlr8g==", "5a0d4e02-e558-4a7b-8e72-ffd4efbb049a" });
        }
    }
}
