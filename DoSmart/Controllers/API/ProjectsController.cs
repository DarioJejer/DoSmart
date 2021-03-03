using DoSmart.Models;
using System.Linq;
using System.Web.Http;

namespace DoSmart.Controllers.API
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Ok(project.Id);
        }
    }
}
