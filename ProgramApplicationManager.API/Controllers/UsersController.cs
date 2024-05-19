using Microsoft.AspNetCore.Mvc;
using ProgramApplicationManager.Domain.DTOs.Request;
using ProgramApplicationManager.Services.Interfaces;

namespace ProgramApplicationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id:string}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = await _userService.CreateUser(request);
            return Ok(user);
        }
    }
}
