using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088926c1-9cee-4c88-aaf5-62bbed2269e8",
                column: "ConcurrencyStamp",
                value: "fc04e551-4031-435a-a63e-7a4156056f12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6df99e-946a-425a-b312-709296422852",
                column: "ConcurrencyStamp",
                value: "2ac825ab-04a2-4311-af7d-5106fee11a9e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf54beb4-a97f-4b93-98be-fdfc1ff12ad1", "AQAAAAIAAYagAAAAEEPnhgk4yQSuAzzJGW57GAVQ8Ygrdp7KAb0c/MZubmU5v8lyWylvt+eZR6++wlyPKg==", "f1521947-f149-41dc-b7e6-4fe053797f45" });
        }
    }
}
