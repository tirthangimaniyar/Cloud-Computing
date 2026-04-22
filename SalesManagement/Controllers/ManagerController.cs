using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Data;
using SalesManagement.Models;
using Microsoft.AspNetCore.Http;

namespace SalesManagement.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsAuthorized()
        {
            return HttpContext.Session.GetString("Role") == "Manager";
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            ViewBag.SalesUserCount = await _context.Users.CountAsync(u => u.Role == "Sales");
            ViewBag.TotalProposals = await _context.Proposals.CountAsync();
            ViewBag.AnnouncementCount = await _context.Announcements.CountAsync();
            ViewBag.PipelineValue = await _context.Opportunities.SumAsync(o => o.ExpectedRevenue);
            ViewBag.TotalOpportunities = await _context.Opportunities.CountAsync();
            ViewBag.RecentSales = await _context.Users.Where(u => u.Role == "Sales").OrderByDescending(u => u.Id).Take(3).ToListAsync();
            return View();
        }

        public async Task<IActionResult> Sales()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var salesUsers = await _context.Users.Where(u => u.Role == "Sales").ToListAsync();
            return View(salesUsers);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Sales");
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            user.Role = "Sales";
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Sales");
        }

        public async Task<IActionResult> EditUser(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var user = await _context.Users.FindAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var existing = await _context.Users.FindAsync(user.Id);
            if (existing != null)
            {
                existing.Username = user.Username;
                existing.Password = user.Password;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Sales");
        }

        public async Task<IActionResult> Announcements()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var announcements = await _context.Announcements.ToListAsync();
            return View(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> Announcements(Announcement announcement)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            announcement.CreatedBy = HttpContext.Session.GetString("Username") ?? "Manager";
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Announcements");
        }

        public async Task<IActionResult> EditAnnouncement(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var announcement = await _context.Announcements.FindAsync(id);
            return View(announcement);
        }

        [HttpPost]
        public async Task<IActionResult> EditAnnouncement(Announcement announcement)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var existing = await _context.Announcements.FindAsync(announcement.Id);
            if (existing != null)
            {
                existing.Message = announcement.Message;
                existing.Date = announcement.Date;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Announcements");
        }

        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Announcements");
        }
    }
}
