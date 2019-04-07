using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Data.Infrastructure;

namespace Solution.Service
{
    public class ServiceUser : Service<User>, IServiceUser
    {
        static DataBaseFactory dbf = new DataBaseFactory();
        static UnitOfWork uow = new UnitOfWork(dbf); 
        public ServiceUser() : base(uow)
        {
        }
    }
}
