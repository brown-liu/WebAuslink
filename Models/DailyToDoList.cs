using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class DailyToDoList

    {   
        [Key]
        public int id { get; set; }
        public DateTime today { get; set; }
        public string? MorningJob { get; set; }
        public string? AfternoonJob { get; set; }
        public string? ExtraWork { get; set; }
       
    }
}
