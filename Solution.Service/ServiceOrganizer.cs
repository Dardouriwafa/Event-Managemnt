using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class ServiceOrganizer : Service<Organizer>, IServiceOrganizer
    {
        static DataBaseFactory dbf = new DataBaseFactory();
        static UnitOfWork uow = new UnitOfWork(dbf);
        public ServiceOrganizer() : base(uow)
        {
        }
    
    }
}
