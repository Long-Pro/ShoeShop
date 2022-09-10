using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.InputModel;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbMapper _dbMapper;


        public CustomerService(IUnitOfWork unitOfWork, IDbMapper dbMapper)
        {
            _unitOfWork = unitOfWork;
            _dbMapper = dbMapper;
        }


        public CustomerDTO Login(LoginModel login)
        {
            var x = _unitOfWork.Customer.Login(login);
            return _dbMapper.mapper.Map<CustomerDTO>(x);
        }
    }
}
