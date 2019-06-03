using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Droid.Scheduler.WebUI.Models
{
    [Table("running")]
    public class Running
    {
        [Key]
        public string id { get; set; }

        [Required]
        public string job { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public string log { get; set; }
    }
}
