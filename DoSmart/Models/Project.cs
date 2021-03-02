using System;

namespace DoSmart.Models
{
    public class Project
    {
        public int Id { get; set; }
        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}