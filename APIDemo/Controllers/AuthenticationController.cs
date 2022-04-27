using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _acctService;

        public AuthenticationController(IAccountService accountService)
        {
            _acctService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response<SignInResponse>>> Login(SignInRequest request)
        {
            var response = await _acctService.Login(request);
            if (response.Data.Tokens.Token == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
