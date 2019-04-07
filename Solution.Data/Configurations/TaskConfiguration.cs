using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class TaskConfiguration: EntityTypeConfiguration<tasks>
    {

        public TaskConfiguration()
        {
            HasOptional(p => p.organizer).WithMany(m => m.tasks).HasForeignKey(p => p.idOrganizer);

        }
    }
}
