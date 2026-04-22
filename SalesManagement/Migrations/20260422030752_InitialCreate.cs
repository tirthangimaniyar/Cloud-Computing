using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChanceToClose = table.Column<int>(type: "int", nullable: false),
                    EstimatedBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "CreatedBy", "Date", "Message" },
                values: new object[,]
                {
                    { 1, "Manager", "2026-04-25", "Quarterly Sales Meeting on Friday at 10 AM." },
                    { 2, "Manager", "2026-04-20", "New commission structure implemented from next month." }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "manager", "Manager", "Manager" },
                    { 2, "sales@01", "Sales", "Sales" },
                    { 3, "pravin", "Sales", "Pravin" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Amount", "ChanceToClose", "ContactMobile", "ContactName", "CreatedUserId", "Description", "Duration", "EstimatedBudget", "IsAccepted", "Name", "Notes", "RejectionReason", "Revenue", "Timestamp" },
                values: new object[,]
                {
                    { 1, 45000m, 80, "1234567890", "John Doe", 2, "Full stack cloud migration for enterprise client.", 60, 50000m, true, "Enterprise Cloud Solution", "High priority project.", "", 9000m, new DateTime(2026, 4, 22, 8, 37, 49, 170, DateTimeKind.Local).AddTicks(4315) },
                    { 2, 14000m, 50, "0987654321", "Jane Smith", 3, "UI/UX redesign of existing mobile app.", 30, 15000m, false, "Mobile App Revamp", "Tight deadline.", "Budget mismatch", 3000m, new DateTime(2026, 4, 22, 8, 37, 49, 170, DateTimeKind.Local).AddTicks(6158) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CreatedUserId",
                table: "Proposals",
                column: "CreatedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
