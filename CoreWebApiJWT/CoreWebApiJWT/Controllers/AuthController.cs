using CoreWebApiJWT.Models;
using CoreWebApiJWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            var result = await _identityService.LoginAsync(loginModel);
            return Ok(result);
        }
        [Route("refresh")]
        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] TokenModel request)
        {
            var result = await _identityService.RefreshTokenAsync(request);
            return Ok(result);
        }
    }
}
