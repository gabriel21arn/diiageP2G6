using back.Data.DTO;
using Back_End.DTO;
using Back_End.Models;
using Back_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/passwords")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordDTO>>> GetPassword()
        {
            var passwords = await _passwordService.GetAllPasswordAsync();
            var passwordDTOs = passwords.Select(password => new PasswordDTO
            {
                password = password
            });

            return Ok(passwordDTOs);
        }
    }
}
