using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IBrandRepository:IRepository<Brand>
    {
        IEnumerable<Brand> GetAllWithJoin();
        Brand GetByIdWithJoin(int id);
    }
}
