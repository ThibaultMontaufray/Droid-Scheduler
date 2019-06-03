using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Droid.Scheduler.WebUI.Models
{
    [Table("job")]
    public class Job
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public bool cyclic { get; set; }

        [Required]
        public string programPath { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime maxStartDate { get; set; }

        [Required]
        public string calendarPath { get; set; }

        [Required]
        public string calendarCountry { get; set; }

        [Required]
        public bool runMonday { get; set; }

        [Required]
        public bool runTuesday { get; set; }

        [Required]
        public bool runWednesday { get; set; }

        [Required]
        public bool runThursday { get; set; }

        [Required]
        public bool runFriday { get; set; }

        [Required]
        public bool runSaturday { get; set; }

        [Required]
        public bool runSunday { get; set; }

        [Required]
        public bool executeOnDelay { get; set; }

        [Required]
        public int runSecond { get; set; }

        [Required]
        public int runMinute { get; set; }

        [Required]
        public int runHour { get; set; }

        [Required]
        public int executeInterval { get; set; }

        [Required]
        public string intervalTimeUnit { get; set; }

        [Required]
        public string rrorMode { get; set; }

        [Required]
        public string multiInstanceMode { get; set; }

        [Required]
        public bool runOnSecond { get; set; }

        [Required]
        public bool runOnMinute { get; set; }

        [Required]
        public bool runOnHour { get; set; }

        [Required]
        public bool maxRunOnSecond { get; set; }

        [Required]
        public bool maxRunOnMinute { get; set; }

        [Required]
        public bool maxRunOnHour { get; set; }

        [Required]
        public int maxRunSecond { get; set; }

        [Required]
        public int maxRunMinute { get; set; }

        [Required]
        public int maxRunHour { get; set; }

        [Required]
        public bool noMaxStartDate { get; set; }

        [Required]
        public string manualJobs { get; set; }
    }
}
