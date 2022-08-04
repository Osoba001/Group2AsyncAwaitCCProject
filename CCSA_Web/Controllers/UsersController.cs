using CCSANoteApp.Domain;
using CCSANoteApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        public IUserService UserService { get; }
        public UsersController(IUserService databaseService)
        {
            UserService = databaseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string username, string email, string password)
        {
            
            return Ok(await UserService.CreateUser(username, email, password));
        }

        [HttpPost("byUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            
            return Ok(await UserService.CreateUser(user.Username, user.Email, user.Password));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            
            return Ok(await UserService.DeleteUser(id));
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            return Ok(await UserService.GetUser(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await UserService.GetUsers());
        }

        [HttpPut("updateemail")]
        public async Task<IActionResult> UpdateEmail(Guid id, string email)
        {
            
            return Ok(await UserService.UpdateUserEmail(id, email););
        }

        [HttpPut("updatename")]
        public async Task<IActionResult> UpdateName(Guid id, string name)
        {
            
            return Ok(await UserService.UpdateUserName(id, name));
        }
    }
}
