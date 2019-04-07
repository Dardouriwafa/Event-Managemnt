using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class tasks
    {
        [Key]
        public int id { get; set; }
        public String description { get; set; }
        public String nom { get; set; }
        public DateTime deadline { get; set; }
        public int? idOrganizer { get; set; }
        [ForeignKey("idOrganizer")]
        public Organizer organizer { get; set; }

    

    }
}
