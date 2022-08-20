using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ShoeRepository:Repository<Shoe>,IShoeRepository
    {
        public ShoeRepository(ShoeShopContext context) : base(context)
        {
        }

        public IEnumerable<Shoe> GetAllWithJoin()
        {
            return _dbSet.Where(x => x.Id != 0)
                .Include(x => x.Brand)
                .ToList();
        }

        public Shoe GetByIdWithJoin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
