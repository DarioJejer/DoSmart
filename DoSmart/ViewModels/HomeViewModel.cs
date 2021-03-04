using DoSmart.Models;
using System.Collections.Generic;

namespace DoSmart.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Activity> ToDoActivities { get; set; }
        public IEnumerable<Activity> DoneActivities { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}