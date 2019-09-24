using System.Threading.Tasks;
using Chetrem.Api.Data;
using Chetrem.Api.Dtos;
using Chetrem.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chetrem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //TODO: validate the request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExist(userForRegisterDto.Username))
            {
                return BadRequest("User already exist");
            }

            var userToCreate = new User
            {

                Username = userForRegisterDto.Username
            };

            var createdUser = _repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201, createdUser);



        }
    }
}