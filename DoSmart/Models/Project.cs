using System;
using System.ComponentModel.DataAnnotations;

namespace DoSmart.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}