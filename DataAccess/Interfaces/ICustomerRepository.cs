using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.InputModel;

namespace DataAccess.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Login(LoginModel login);
    }
}