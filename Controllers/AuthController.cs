using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApis_Mssql_Docker.Models.Auth;

namespace NetCoreApis_Mssql_Docker.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /login
        ///     {
        ///        "userName": "myusername",
        ///        "password": "mypassword"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Returns token</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login req)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest();

                var r = _authService.Login(req);
                return Ok(new { result = true, resultmessage = r });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, resultmessage = ex.Message });
            }
        }
    }
}