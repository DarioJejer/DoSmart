using DoSmart.Models;
using System.Collections.Generic;

namespace DoSmart.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}