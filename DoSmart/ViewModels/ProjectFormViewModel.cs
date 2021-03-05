using System.ComponentModel.DataAnnotations;

namespace DoSmart.ViewModels
{
    public class ProjectFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string PageHeader { get; set; }
    }
}