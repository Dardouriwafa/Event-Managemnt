using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
   public class GeneralUserConfiguration : EntityTypeConfiguration<GeneralUser>
    {
        public GeneralUserConfiguration()
        {
            Map<Organizer>(b => b.Requires("isOrganazer").HasValue(0));
            Map<Speaker>(b => b.Requires("isSpeaker").HasValue(0));
            Map<User>(b => b.Requires("isUser").HasValue(0));
        }
    }
}
