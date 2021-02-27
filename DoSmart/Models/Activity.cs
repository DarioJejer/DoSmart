using System;

namespace DoSmart.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public ImportanceCategory ImportanceCategory { get; set; }
        public byte ImportanceCategoryId { get; set; }
        public bool Done { get; set; }
    }
}