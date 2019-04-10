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
    public class ServiceTask : Service<tasks>, IServiceTask
    {
        static IDataBaseFactory dbf = new DataBaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceTask() : base(uow)
        {
        }

        public int count()
        {
            throw new NotImplementedException();
        }

        public int count(int id)

        {

            int simple = GetAll().Count();

            return simple;

        }
        public  IEnumerable<tasks> SearchTaskByName(string searchString)
        {
            IEnumerable<tasks> task = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                task = GetMany(x => x.nom.Contains(searchString));
            }
            return task;
        }

    }
}
