using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BrandRepository: Repository<Brand>,IBrandRepository
    {
        public BrandRepository(ShoeShopContext context) : base(context)
        {
        }

        public IEnumerable<Brand> GetAllBrand()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<Brand> GetAllBrandWithShoe()
        {
            return _dbSet
                .Include(x => x.Shoes)
                .ToList();
        }

        public Brand GetBrandById(int id)
        {
            return _dbSet.Where(x => x.Id == id)
                .FirstOrDefault();
        }


        public Brand GetBrandByIdWithShoe(int id)
        {
            return _dbSet.Where(x => x.Id == id)
                .Include(x => x.Shoes)
                .FirstOrDefault();
        }
    }
}
