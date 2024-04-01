using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "PK", new DateTime(2024, 3, 30, 15, 40, 10, 918, DateTimeKind.Local).AddTicks(6563), 10, "PK", new DateTime(2024, 3, 30, 15, 40, 10, 918, DateTimeKind.Local).AddTicks(6573), "Vacation" },
                    { 2, "PK", new DateTime(2024, 3, 30, 15, 40, 10, 918, DateTimeKind.Local).AddTicks(6575), 12, "PK", new DateTime(2024, 3, 30, 15, 40, 10, 918, DateTimeKind.Local).AddTicks(6576), "Sick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
