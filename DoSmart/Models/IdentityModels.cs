using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DoSmart.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ImportanceCategory> ImportanceCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}