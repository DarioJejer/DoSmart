using System;
using System.ComponentModel.DataAnnotations;

namespace DoSmart.Models
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public byte ImportanceCategoryId { get; set; }
        public ImportanceCategory ImportanceCategory { get; set; }
        public bool Done { get; set; }
        public string GetImportanceColor()
        {
            switch (ImportanceCategoryId)
            {
                case 2:
                    return "#b6ff00";
                case 3:
                    return "#ffd800";
                case 4:
                    return "#f97d24";
                default:
                    return "white";
            }
        }
    }
}