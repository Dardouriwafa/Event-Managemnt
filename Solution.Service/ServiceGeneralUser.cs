using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;

namespace Solution.Service
{
    public class ServiceGeneralUser : Service<GeneralUser>, IServiceGeneralUser
    {
        static DataBaseFactory dbf = new DataBaseFactory();
        static UnitOfWork uow = new UnitOfWork(dbf);
        public ServiceGeneralUser() : base(uow)
        {
        }

    }
}
