using CourseManagementApi.Contracts;
using CourseManagementApi.Models.Users;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] ApiUserDTO apiUserDTO)
        {
            var errors =await  _authManager.Register(apiUserDTO);
            if(errors.Any())
            {
                foreach(var error in errors)
                {
                     ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok("User is succesfully registered");
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
           var authResponse=await _authManager.Login(loginUserDTO);
            
            if(authResponse==null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
    }
}
