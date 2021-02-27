using DoSmart.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DoSmart.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var activities = _context.Activities
                .Include(a => a.Creator)
                .Include(a => a.ImportanceCategory)
                .Where(a => a.CreatorId == userId)
                .OrderByDescending(a => a.ImportanceCategoryId)
                .ToList();
            return View(activities);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}