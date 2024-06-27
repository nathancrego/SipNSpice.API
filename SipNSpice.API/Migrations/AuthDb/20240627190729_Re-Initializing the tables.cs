using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipNSpice.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class ReInitializingthetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "088926c1-9cee-4c88-aaf5-62bbed2269e8",
                column: "ConcurrencyStamp",
                value: "2346451e-a969-449c-900c-3f88ee3e9176");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6df99e-946a-425a-b312-709296422852",
                column: "ConcurrencyStamp",
                value: "69bf2e63-e29e-49ee-9337-20b7b5b09fb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d571cde-ba20-4e7b-92b0-b7a2b70e0e99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1186636f-f587-4e20-9696-c154babd1e73", "AQAAAAIAAYagAAAAENDKAghRzY3LW2+s8mHavmzDEkPg1YaVRFr4AYY4myYk0iz4/Fqm40VwNEoroB/C5g==", "9c1ac1f6-236a-4b2e-bbfa-ffd279bfaa77" });
        }
    }
}
