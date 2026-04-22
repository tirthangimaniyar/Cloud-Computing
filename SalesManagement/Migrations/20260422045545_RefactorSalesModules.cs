using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesManagement.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSalesModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AssignedManager",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Completion",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Spent",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ClientTypes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "ProjectName");

            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "Opportunities",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ExpectedCloseDate",
                table: "Opportunities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DealValue",
                table: "Opportunities",
                newName: "ExpectedRevenue");

            migrationBuilder.RenameColumn(
                name: "ClientType",
                table: "Opportunities",
                newName: "ClientName");

            migrationBuilder.AddColumn<int>(
                name: "ProposalId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Business to Business", "B2B" });

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Business to Consumer", "B2C" });

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Public sector", "Government" });

            migrationBuilder.UpdateData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientName", "CreatedDate", "ExpectedRevenue", "Status", "Title" },
                values: new object[] { "GlobalCorp", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150000m, "Open", "Main Server Migration" });

            migrationBuilder.UpdateData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClientName", "CreatedDate", "Status", "Title" },
                values: new object[] { "LocalStore", new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Won", "POS System Setup" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "ProjectName", "ProposalId", "StartDate" },
                values: new object[] { new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloud Alpha", 1, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProposalId",
                table: "Projects",
                column: "ProposalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Proposals_ProposalId",
                table: "Projects",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Proposals_ProposalId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProposalId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Projects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Opportunities",
                newName: "Stage");

            migrationBuilder.RenameColumn(
                name: "ExpectedRevenue",
                table: "Opportunities",
                newName: "DealValue");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Opportunities",
                newName: "ExpectedCloseDate");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Opportunities",
                newName: "ClientType");

            migrationBuilder.AddColumn<string>(
                name: "AssignedManager",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientType",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Spent",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Opportunities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Opportunities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Opportunities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Probability",
                table: "Opportunities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ClientTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "ClientTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "Name", "Priority" },
                values: new object[] { "#e07070", "Large scale corporations", "Enterprise", "High" });

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Description", "Name", "Priority" },
                values: new object[] { "#1abc9c", "Small and Medium Businesses", "SMB", "Medium" });

            migrationBuilder.UpdateData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "Description", "Name", "Priority" },
                values: new object[] { "#3498db", "Early stage ventures", "Startup", "Medium" });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "Color", "Description", "Name", "Priority" },
                values: new object[,]
                {
                    { 4, "#9b59b6", "Public sector entities", "Government", "High" },
                    { 5, "#f39c12", "Charitable organizations", "NGO/Non-profit", "Low" }
                });

            migrationBuilder.UpdateData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientType", "ContactName", "ContactPhone", "DealValue", "ExpectedCloseDate", "Notes", "Probability", "Stage", "Title" },
                values: new object[] { "Enterprise", "Mike Ross", "555-0101", 75000m, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 80, "Proposal Sent", "Tech Upgrade 2026" });

            migrationBuilder.UpdateData(
                table: "Opportunities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClientType", "ContactName", "ContactPhone", "ExpectedCloseDate", "Notes", "Probability", "Stage", "Title" },
                values: new object[] { "Startup", "Rachel Zane", "555-0202", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, "Qualification", "Web Redesign" });

            migrationBuilder.InsertData(
                table: "Opportunities",
                columns: new[] { "Id", "ClientType", "ContactName", "ContactPhone", "CreatedUserId", "DealValue", "ExpectedCloseDate", "Notes", "Probability", "Stage", "Title" },
                values: new object[,]
                {
                    { 3, "Government", "Harvey Specter", "555-0303", 3, 45000m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50, "Needs Analysis", "Security Audit" },
                    { 4, "SMB", "Louis Litt", "555-0404", 3, 30000m, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, "Closed Won", "Infrastructure Refresh" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AssignedManager", "Budget", "ClientName", "ClientType", "Completion", "EndDate", "Name", "Spent", "StartDate" },
                values: new object[] { "Sarah Paulson", 100000m, "GlobalCorp", "Enterprise", 45, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alpha Migration", 45000m, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AssignedManager", "Budget", "ClientName", "ClientType", "Completion", "CreatedUserId", "EndDate", "Name", "Spent", "StartDate", "Status" },
                values: new object[,]
                {
                    { 2, "Tom Hardy", 20000m, "FastStart", "Startup", 80, 2, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beta Launch", 19000m, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "At Risk" },
                    { 3, "Jessica Chen", 60000m, "City Council", "Government", 5, 3, new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gamma Portal", 5000m, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planning" },
                    { 4, "Bill Gates", 15000m, "MainStreet Retail", "SMB", 100, 3, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delta Support", 15000m, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "Amount", "ChanceToClose", "ContactMobile", "ContactName", "CreatedUserId", "Description", "Duration", "EstimatedBudget", "IsAccepted", "Name", "Notes", "RejectionReason", "Revenue", "Timestamp" },
                values: new object[] { 2, 14000m, 50, "0987654321", "Jane Smith", 3, "UI/UX redesign of existing mobile app.", 30, 15000m, false, "Mobile App Revamp", "Tight deadline.", "Budget mismatch", 3000m, new DateTime(2026, 4, 15, 14, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
