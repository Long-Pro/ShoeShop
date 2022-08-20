
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandService _brandService;



        public BrandController(IUnitOfWork unitOfWork,IBrandService brandService)
        {
            _unitOfWork = unitOfWork;
            _brandService = brandService;
        }

        [HttpGet("GetBrandById")]
        public BrandDTO GetBrandById(int id)
        {
            return _brandService.GetBrandById(1);
        }
    }
}
