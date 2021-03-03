using DoSmart.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoSmart.ViewModels
{
    public class ActivityFormViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        [Display(Name = "Importance")]
        public byte ImportanceCategoryId { get; set; }
        public IEnumerable<ImportanceCategory> ImportanceCategories { get; set; }
        public string Action { get; set; }
        public string PageHeader { get; set; }

    }
}