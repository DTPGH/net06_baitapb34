using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CreatedAt", "Deleted", "Description", "Email", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(6745), false, "Người dùng mẫu", "nguyenvana@example.com", "Nguyen Van A", new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7081) },
                    { 2, 25, new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7705), false, "Dữ liệu mẫu thứ hai", "tranthib@example.com", "Tran Thi B", new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7705) },
                    { 3, 35, new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7707), false, "Dữ liệu mẫu thứ ba", "levanc@example.com", "Le Van C", new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7708) },
                    { 4, 28, new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7709), false, "Dữ liệu mẫu thứ tư", "phamthid@example.com", "Pham Thi D", new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7710) },
                    { 5, 32, new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7712), false, "Dữ liệu mẫu thứ năm", "hoangvane@example.com", "Hoang Van E", new DateTime(2026, 5, 26, 16, 42, 22, 525, DateTimeKind.Local).AddTicks(7712) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
