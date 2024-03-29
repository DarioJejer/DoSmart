﻿using DoSmart.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoSmart.ViewModels
{
    public class ActivityFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Importance")]
        public byte ImportanceCategoryId { get; set; }
        public IEnumerable<ImportanceCategory> ImportanceCategories { get; set; }
        public string Action { get; set; }
        public string PageHeader { get; set; }

    }
}