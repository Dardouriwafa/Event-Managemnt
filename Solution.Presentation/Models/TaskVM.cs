using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class TaskVM
    {
        public int id { get; set; }
        public String description { get; set; }
        public String nom { get; set; }
        [DataType(DataType.Date)]
        public DateTime deadline { get; set; }
        public int? idOrganizer { get; set; }
        
        
    }
}