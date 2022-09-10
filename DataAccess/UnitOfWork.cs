using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace DataAccess
{
    public class UnitOfWork:IUnitOfWork
    {
        private ShoeShopContext _context;
        public UnitOfWork(ShoeShopContext context)
        {
            this._context = context;
            Brand = new BrandRepository(this._context);
            Shoe = new ShoeRepository(this._context);
            Review = new ReviewRepository(this._context);
            Customer = new CustomerRepository(this._context);
        }
        public IBrandRepository Brand { get; private set; }
            
        public IShoeRepository Shoe { get; private set; }
        public IReviewRepository Review { get; private set; }
        public ICustomerRepository Customer { get; private set; }


        public void Dispose()
        {
            _context.Dispose();
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
