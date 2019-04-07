using Solution.Data.Configurations;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {
        public MyContext():base("name=event")
        {

        }
        // dbset
      
        public DbSet<tasks> tasks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new GeneralUserConfiguration());
        }
        public static MyContext Create()
        {
            return new MyContext();
        }
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }








    }
}
