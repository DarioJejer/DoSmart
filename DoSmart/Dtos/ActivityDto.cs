using DoSmart.Models;
using System;

namespace DoSmart.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public ImportanceCategory ImportanceCategory { get; set; }
        public byte ImportanceCategoryId { get; set; }
        public bool Done { get; set; }

        public string ImportanceColor
        {
            get
            {
                switch (ImportanceCategoryId)
                {
                    case 1:
                        return "#ffd800";
                    case 2:
                        return "#ff6a00";
                    case 3:
                        return "#ff0000";
                    default:
                        return "white";
                }
            }
        }
    }
}