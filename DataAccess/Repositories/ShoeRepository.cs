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

        public IEnumerable<Shoe> GetAllShoe()
        {
            return _dbSet.ToList();
        }
        public IEnumerable<Shoe> GetAllShoeWithFile()
        {
            return _dbSet
                .Include(x => x.ShoeFiles)
                .ToList();
        }

        public IEnumerable<Shoe> GetAllShoeWithFileAndBrand()
        {
            return _dbSet
                .Include(x => x.ShoeFiles)
                .Include(x => x.Brand)
                .ToList();
        }

        public Shoe GetShoeById(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }



        public Shoe GetShoeByIdWithFile(int id)
        {
            var x= _dbSet.Where(x => x.Id == id)
                .Include(x => x.ShoeFiles)
                .FirstOrDefault();
            return x;
            /*return _dbSet.Where(x => x.Id == id)
                .Include(x => x.ShoeFiles)
                .FirstOrDefault();*/


            //throw new NotImplementedException();
        }
    }
}
