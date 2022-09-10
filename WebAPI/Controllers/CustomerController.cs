using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper.QueryableExtensions.Impl;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.InputModel;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using _BCrypt = BCrypt.Net.BCrypt;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public IConfiguration _configuration;

        public CustomerController(ICustomerService customerService, IConfiguration config)
        {
            _customerService = customerService;
            _configuration = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            var hashPassword = _BCrypt.HashPassword(login.Password);
            Console.WriteLine(hashPassword);
            var x = _customerService.Login(login);

            if (x == null) return NotFound(new ApiResponse("Không tìm thấy dữ liệu"));
            string jwt = CreateToken(x);

            return Ok(new ApiResponse("Lấy dữ liệu thành công", jwt));
        }

        private string CreateToken(CustomerDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}