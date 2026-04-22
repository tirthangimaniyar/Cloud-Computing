using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Data;
using SalesManagement.Models;
using Microsoft.AspNetCore.Http;

namespace SalesManagement.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool IsAuthorized()
        {
            return HttpContext.Session.GetString("Role") == "Sales";
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.ProposalCount = await _context.Proposals.CountAsync(p => p.CreatedUserId == userId);
            ViewBag.RecentAnnouncements = await _context.Announcements.OrderByDescending(a => a.Id).Take(3).ToListAsync();
            return View();
        }

        public async Task<IActionResult> Proposals()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var proposals = await _context.Proposals.Include(p => p.CreatedBy).ToListAsync();
            return View(proposals);
        }

        [HttpPost]
        public async Task<IActionResult> AddProposal(Proposal proposal)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            proposal.CreatedUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            proposal.Timestamp = DateTime.Now;
            _context.Proposals.Add(proposal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Proposals");
        }

        public async Task<IActionResult> DeleteProposal(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var proposal = await _context.Proposals.FindAsync(id);
            if (proposal != null)
            {
                _context.Proposals.Remove(proposal);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Proposals");
        }

        // --- CLIENT TYPE ---
        public async Task<IActionResult> ClientType()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var types = await _context.ClientTypes.ToListAsync();
            return View(types);
        }

        [HttpPost]
        public async Task<IActionResult> ClientType(ClientType clientType)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            if (clientType.Id == 0) _context.ClientTypes.Add(clientType);
            else _context.Update(clientType);
            await _context.SaveChangesAsync();
            return RedirectToAction("ClientType");
        }

        public async Task<IActionResult> DeleteClientType(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var ct = await _context.ClientTypes.FindAsync(id);
            if (ct != null) { _context.ClientTypes.Remove(ct); await _context.SaveChangesAsync(); }
            return RedirectToAction("ClientType");
        }

        // --- OPPORTUNITIES ---
        public async Task<IActionResult> Opportunities()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var opportunities = await _context.Opportunities.ToListAsync();
            return View(opportunities);
        }

        [HttpPost]
        public async Task<IActionResult> Opportunities(Opportunity opportunity)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            opportunity.CreatedUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (opportunity.Id == 0) _context.Opportunities.Add(opportunity);
            else _context.Update(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Opportunities");
        }

        public async Task<IActionResult> ConvertOpportunity(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var opp = await _context.Opportunities.FindAsync(id);
            if (opp != null)
            {
                var proposal = new Proposal
                {
                    Name = opp.Title,
                    Description = opp.ClientName,
                    Amount = opp.ExpectedRevenue,
                    CreatedUserId = HttpContext.Session.GetInt32("UserId") ?? 0,
                    Timestamp = DateTime.Now
                };
                _context.Proposals.Add(proposal);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Proposals");
        }

        public async Task<IActionResult> DeleteOpportunity(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var opp = await _context.Opportunities.FindAsync(id);
            if (opp != null) { _context.Opportunities.Remove(opp); await _context.SaveChangesAsync(); }
            return RedirectToAction("Opportunities");
        }

        // --- PROJECTS ---
        public async Task<IActionResult> Projects()
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var projects = await _context.Projects.Include(p => p.Proposal).ToListAsync();
            ViewBag.Proposals = await _context.Proposals.ToListAsync();
            return View(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Projects(Project project)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            project.CreatedUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (project.Id == 0) _context.Projects.Add(project);
            else _context.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Projects");
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            if (!IsAuthorized()) return RedirectToAction("Login", "Account");
            var project = await _context.Projects.FindAsync(id);
            if (project != null) { _context.Projects.Remove(project); await _context.SaveChangesAsync(); }
            return RedirectToAction("Projects");
        }
    }
}
