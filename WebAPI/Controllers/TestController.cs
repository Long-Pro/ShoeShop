using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Brand> GetAll()
        {
            return unitOfWork.Brand.GetAll();
        }
        [HttpGet("GetAllWithJoin")]
        public IEnumerable<Brand> GetAllWithJoin()
        {
            return unitOfWork.Brand.GetAllWithJoin();
        }

        [HttpGet("GetBrandById")]
        public Brand GetById(int id)
        {
            var x= unitOfWork.Brand.GetById(id);
            return x;
        }
        [HttpGet("GetByIdWithJoin")]
        public Brand GetByIdWithJoin(int id)
        {
            var x = unitOfWork.Brand.GetByIdWithJoin(id);
            return x;
        }

        [HttpGet("GetAllShoeWithJoin")]
        public IEnumerable<Shoe> GetAllShoeWithJoin()
        {
            return unitOfWork.Shoe.GetAllWithJoin();
        }
    }
}
