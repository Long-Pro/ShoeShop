using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;
using DataAccess.InputModel;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO Login(LoginModel login);
    }
}
