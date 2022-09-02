using AutoMapper.QueryableExtensions.Impl;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.InputModel;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/shoes")]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeService _shoeService;

        public ShoeController(IUnitOfWork unitOfWork, IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet("GetShoeById")]
        public IActionResult GetShoeById(int id)
        {
            var x = _shoeService.GetShoeById(id);
            //throw new Exception("xxxxxxxxxxxxxx");

            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("GetShoeByIdWithFile")]
        public IActionResult GetShoeByIdWithFile(int id)
        {
            var x = _shoeService.GetShoeByIdWithFile(id);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("GetAllShoe")]
        public IActionResult GetAllShoe()
        {
            var x = _shoeService.GetAllShoe();
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("GetAllShoeWithFile")]
        public IActionResult GetAllShoeWithFile()
        {
            var x = _shoeService.GetAllShoeWithFile();
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("")]
        public IActionResult FilterShoeByName([FromQuery] ShoeFilter filter)
        {
            int totalPage;
            var x = _shoeService.FilterShoe(filter, out totalPage);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x, totalPage));
        }
    }
}