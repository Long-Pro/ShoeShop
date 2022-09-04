using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Interfaces;
using DataAccess.Entities;
using DataAccess.InputModel;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public class ShoeRepository : Repository<Shoe>, IShoeRepository
    {
        public ShoeRepository(ShoeShopContext context) : base(context)
        {
        }

        public IEnumerable<Shoe> FilterShoe(ShoeFilter filter, out int totalPage)
        {
            const int PAGE_SIZE = 12;
            var sql = _dbSet
                .Where(x => filter.brandId == null || x.BrandId == filter.brandId)
                .Where(x => (filter.priceStart == null || filter.priceEnd == null) ||
                            (x.Price >= filter.priceStart && x.Price <= filter.priceEnd))
                .Where(x => string.IsNullOrWhiteSpace(filter.q) || x.Name.Contains(filter.q));
            var totalRecord = sql.Count();
            totalPage = (int)Math.Ceiling((totalRecord * 1.0 / PAGE_SIZE));


            return sql
                .Include(x => x.Brand)
                .Include(x => x.ShoeFiles.OrderBy(x => x.FileOrder).Take(2))
                .OrderBy(x => filter.sort == SortBy.PRICE_ASC ? x.Price : 0)
                .ThenByDescending(x => filter.sort == SortBy.PRICE_DESC ? x.Price : 0)
                .ThenBy(x => filter.sort == SortBy.NAME_ASC ? x.Name : null)
                .ThenByDescending(x => filter.sort == SortBy.NAME_DESC ? x.Name : null)
                .Skip(PAGE_SIZE * (filter.page - 1))
                .Take(PAGE_SIZE)
                .ToList();
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
            return _dbSet.Where(x => x.Id == id)
                .Include(x => x.ShoeColors)
                .ThenInclude(x => x.ShoeStores)
                .Include(x => x.Brand)
                .Include(x => x.ShoeFiles.OrderBy(x => x.FileOrder))
                .FirstOrDefault();
        }


        public Shoe GetShoeByIdWithFile(int id)
        {
            var x = _dbSet.Where(x => x.Id == id)
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