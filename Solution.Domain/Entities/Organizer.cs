using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Organizer :GeneralUser
    {
        public virtual  ICollection<tasks> tasks { get; set; }

    }
}
