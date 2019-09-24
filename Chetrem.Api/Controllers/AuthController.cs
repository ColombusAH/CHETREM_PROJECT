using System.Threading.Tasks;
using Chetrem.Api.Data;
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
        public async Task<IActionResult> Register(string username, string password)
        {
            //TODO: validate the request
            username = username.ToLower();

            if (await _repo.UserExist(username))
            {
                return BadRequest("User already exist");
            }

            var userToCreate = new User
            {

                Username = username
            };

            var createdUser = _repo.Register(userToCreate, password);
            return StatusCode(201, createdUser);



        }
    }
}