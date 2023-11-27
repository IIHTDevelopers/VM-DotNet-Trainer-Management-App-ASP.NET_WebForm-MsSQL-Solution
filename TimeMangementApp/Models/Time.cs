using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeManagementApp.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public TimeSpan Duration { get; set; }
        public string Notes { get; set; }
    }
}