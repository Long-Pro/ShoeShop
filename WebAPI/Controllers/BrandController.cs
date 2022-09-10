
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetBrandById")]
        public IActionResult GetBrandById(int id)
        {
            var x = _brandService.GetBrandById(id);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("GetBrandByIdWithShoe")]
        public IActionResult GetBrandByIdWithShoe(int id)
        {
            var x = _brandService.GetBrandByIdWithShoe(id);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("")]
        public IActionResult GetAllBrand()
        {
            var x = _brandService.GetAllBrand();
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("GetAllBrandWithShoe")]
        public IActionResult GetAllBrandWithShoe()
        {
            var x = _brandService.GetAllBrandWithShoe();
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }
    }
}
