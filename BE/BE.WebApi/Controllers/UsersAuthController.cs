using BE.Application.Features.UserAuth.Commands.UserRegister;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UsersAuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterEmployeeAsync(UserEmployeeRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        
    }  
}
