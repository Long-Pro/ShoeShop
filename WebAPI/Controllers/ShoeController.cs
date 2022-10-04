using AutoMapper.QueryableExtensions.Impl;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.InputModel;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/shoes")]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeService _shoeService;
        private readonly IReviewService _reviewService;


        public ShoeController(IUnitOfWork unitOfWork, IShoeService shoeService, IReviewService reviewService)
        {
            _shoeService = shoeService;
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public IActionResult GetShoeById(int id)
        {
            var x = _shoeService.GetShoeById(id);
            //throw new Exception("xxxxxxxxxxxxxx");

            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", x));
        }

        [HttpGet("test"), Authorize]
        public IActionResult Test()
        {
            return Ok(new ApiResponse("Lấy dữ liệu thành công", "1234"));
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetReviewsByShoeId(int id, int page)
        {
            int totalPage;
            var x = _reviewService.GetReviewsByShoeId(id, page, out totalPage);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", new { totalPage = totalPage, value = x }));
        }


        [HttpGet("")]
        public IActionResult FilterShoeByName([FromQuery] ShoeFilterModel filter)
        {
            int totalPage;
            var x = _shoeService.FilterShoe(filter, out totalPage);
            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            return Ok(new ApiResponse("Lấy dữ liệu thành công", new { totalPage = totalPage, value = x }));
        }
    }
}