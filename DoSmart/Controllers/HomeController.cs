using DoSmart.Models;
using DoSmart.ViewModels;
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
        public ActionResult Index(int id)
        {
            var userId = User.Identity.GetUserId();
            var activities = _context.Activities
                .Include(a => a.Creator)
                .Include(a => a.ImportanceCategory)
                .Include(a => a.Project)
                .Where(a => a.CreatorId == userId && a.ProjectId == id)
                .OrderByDescending(a => a.ImportanceCategoryId);

            var projects = _context.Projects
                .Where(p => p.CreatorId == userId);

            var toDoActivities = activities.Where(a => !a.Done).ToList();
            var doneActivities = activities.Where(a => a.Done).ToList();

            var viewModel = new HomeViewModel()
            {
                ToDoActivities = toDoActivities,
                DoneActivities = doneActivities,
                Projects = projects,
                SelectedProjectId = id
            };

            return View(viewModel);
        }
    }
}