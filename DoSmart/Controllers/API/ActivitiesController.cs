using DoSmart.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace DoSmart.Controllers.API
{
    public class ActivitiesController : ApiController
    {
        private ApplicationDbContext _context;

        public ActivitiesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Check(int id)
        {
            var activity = _context.Activities.SingleOrDefault(a => a.Id == id);

            if (activity == null)
                return NotFound();
            if (activity.CreatorId != User.Identity.GetUserId())
                return BadRequest();

            activity.Done = !activity.Done;
            _context.SaveChanges();
            return Ok(activity.Id);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var activity = _context.Activities.SingleOrDefault(a => a.Id == id);

            if (activity == null)
                return NotFound();

            _context.Activities.Remove(activity);
            _context.SaveChanges();

            return Ok(activity.Id);
        }
    }
}
