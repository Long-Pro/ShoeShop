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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ShoeShopContext context) : base(context)
        {
        }


        public IEnumerable<Review> GetReviewsByShoeId(int id, int page, out int totalPage)
        {
            const int PAGE_SIZE = 5;
            var sql = _dbSet.Where(x => x.ShoeId == id);
            var totalRecord = sql.Count();
            totalPage = (int)Math.Ceiling((totalRecord * 1.0 / PAGE_SIZE));
            return sql
                .Include(x => x.Customer)
                .ThenInclude(x => x.Account)
                .Include(x => x.ReviewFiles)
                .Skip(PAGE_SIZE * (page - 1))
                .Take(PAGE_SIZE)
                .ToList();
        }
    }
}
