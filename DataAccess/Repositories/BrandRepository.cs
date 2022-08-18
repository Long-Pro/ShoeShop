using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BrandRepository: Repository<Brand>,IBrandRepository
    {
        public BrandRepository(ShoeShopContext context) : base(context)
        {
        }

        public IEnumerable<Brand> GetAllWithJoin()
        {
            return _dbSet.Where(x=>x.Id!=0)
                .Include(x=>x.Shoes)
                .ToList();
        }


        public Brand GetByIdWithJoin(int id)
        {
            return _dbSet.Where(x => x.Id == id)
                .Include(x => x.Shoes)
                .FirstOrDefault();
        }
    }
}
