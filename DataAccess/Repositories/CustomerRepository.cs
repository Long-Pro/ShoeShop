using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Entities;
using DataAccess.InputModel;
using Microsoft.EntityFrameworkCore;
using _BCrypt = BCrypt.Net.BCrypt;


namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShoeShopContext context) : base(context)
        {
        }


        public Customer Login(LoginModel login)
        {
            var hashPassword = _BCrypt.HashPassword(login.Password);
            var x = _dbSet
                .Where(x => x.Account.AccountValue == login.Account)
                .Include(x => x.Account)
                .FirstOrDefault();
            try
            {
                return _BCrypt.Verify(login.Password, x.Account.Password) ? x : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
