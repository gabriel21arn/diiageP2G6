using back.Data.DTO;
using Back_End.DTO;
using Back_End.Models;
using Back_End.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /api/users - Récupérer tous les utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email
            });

            return Ok(userDTOs);
        }

        // POST /api/users - Ajouter un nouvel utilisateur
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Les informations de l'utilisateur sont requises.");
            }

            var newUser = new User
            {
                Nom = userDto.Nom,
                Prenom = userDto.Prenom,
                Email = userDto.Email,
                MotDePasse = userDto.MotDePasse,
                ApplicationId = userDto.ApplicationId
            };

            var createdUser = await _userService.CreateUserAsync(newUser);

            var createdUserDTO = new UserDTO
            {
                Id = createdUser.Id,
                Nom = createdUser.Nom,
                Prenom = createdUser.Prenom,
                Email = createdUser.Email
            };

            return CreatedAtAction(nameof(GetUsers), new { id = createdUserDTO.Id }, createdUserDTO);
        }
    }
}
