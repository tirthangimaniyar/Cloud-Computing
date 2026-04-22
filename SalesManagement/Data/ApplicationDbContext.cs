using Microsoft.EntityFrameworkCore;
using SalesManagement.Models;

namespace SalesManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Manager", Password = "manager", Role = "Manager" },
                new User { Id = 2, Username = "Sales", Password = "sales@01", Role = "Sales" },
                new User { Id = 3, Username = "Pravin", Password = "pravin", Role = "Sales" }
            );

            // Seed ClientTypes
            modelBuilder.Entity<ClientType>().HasData(
                new ClientType { Id = 1, Name = "B2B", Description = "Business to Business" },
                new ClientType { Id = 2, Name = "B2C", Description = "Business to Consumer" },
                new ClientType { Id = 3, Name = "Government", Description = "Public sector" }
            );

            // Seed Proposals
            modelBuilder.Entity<Proposal>().HasData(
                new Proposal
                {
                    Id = 1,
                    Name = "Enterprise Cloud Solution",
                    CreatedUserId = 2,
                    Timestamp = new DateTime(2026, 4, 1, 10, 0, 0),
                    ChanceToClose = 80,
                    EstimatedBudget = 50000,
                    Duration = 60,
                    ContactName = "John Doe",
                    ContactMobile = "1234567890",
                    Description = "Full stack cloud migration for enterprise client.",
                    Notes = "High priority project.",
                    Amount = 45000,
                    Revenue = 9000,
                    IsAccepted = true
                }
            );

            // Seed Opportunities
            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity { Id = 1, ClientName = "GlobalCorp", Title = "Main Server Migration", ExpectedRevenue = 150000, Status = "Open", CreatedDate = new DateTime(2026, 4, 1), CreatedUserId = 2 },
                new Opportunity { Id = 2, ClientName = "LocalStore", Title = "POS System Setup", ExpectedRevenue = 12000, Status = "Won", CreatedDate = new DateTime(2026, 4, 10), CreatedUserId = 2 }
            );

            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProposalId = 1, ProjectName = "Cloud Alpha", StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 8, 30), Status = "In Progress", CreatedUserId = 2 }
            );

            // Seed Announcements
            modelBuilder.Entity<Announcement>().HasData(
                new Announcement { Id = 1, Message = "Quarterly Sales Meeting on Friday at 10 AM.", Date = "2026-04-25", CreatedBy = "Manager" },
                new Announcement { Id = 2, Message = "New commission structure implemented from next month.", Date = "2026-04-20", CreatedBy = "Manager" }
            );
        }
    }
}
