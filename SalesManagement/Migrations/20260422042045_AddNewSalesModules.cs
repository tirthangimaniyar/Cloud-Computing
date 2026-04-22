using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddNewSalesModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false),
                    ExpectedCloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Spent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completion = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "Color", "Description", "Name", "Priority" },
                values: new object[,]
                {
                    { 1, "#e07070", "Large scale corporations", "Enterprise", "High" },
                    { 2, "#1abc9c", "Small and Medium Businesses", "SMB", "Medium" },
                    { 3, "#3498db", "Early stage ventures", "Startup", "Medium" },
                    { 4, "#9b59b6", "Public sector entities", "Government", "High" },
                    { 5, "#f39c12", "Charitable organizations", "NGO/Non-profit", "Low" }
                });

            migrationBuilder.InsertData(
                table: "Opportunities",
                columns: new[] { "Id", "ClientType", "ContactName", "ContactPhone", "CreatedUserId", "DealValue", "ExpectedCloseDate", "Notes", "Probability", "Stage", "Title" },
                values: new object[,]
                {
                    { 1, "Enterprise", "Mike Ross", "555-0101", 2, 75000m, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, "Proposal Sent", "Tech Upgrade 2026" },
                    { 2, "Startup", "Rachel Zane", "555-0202", 2, 12000m, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, "Qualification", "Web Redesign" },
                    { 3, "Government", "Harvey Specter", "555-0303", 3, 45000m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, "Needs Analysis", "Security Audit" },
                    { 4, "SMB", "Louis Litt", "555-0404", 3, 30000m, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, "Closed Won", "Infrastructure Refresh" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AssignedManager", "Budget", "ClientName", "ClientType", "Completion", "CreatedUserId", "EndDate", "Name", "Spent", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "Sarah Paulson", 100000m, "GlobalCorp", "Enterprise", 45, 2, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alpha Migration", 45000m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Progress" },
                    { 2, "Tom Hardy", 20000m, "FastStart", "Startup", 80, 2, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beta Launch", 19000m, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "At Risk" },
                    { 3, "Jessica Chen", 60000m, "City Council", "Government", 5, 3, new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gamma Portal", 5000m, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planning" },
                    { 4, "Bill Gates", 15000m, "MainStreet Retail", "SMB", 100, 3, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delta Support", 15000m, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CreatedUserId",
                table: "Opportunities",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedUserId",
                table: "Projects",
                column: "CreatedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
