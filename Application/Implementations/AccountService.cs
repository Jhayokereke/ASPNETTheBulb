using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IJWTManager _jwtManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountService(IJWTManager jWTManager, UserManager<AppUser> userManager)
        {
            _jwtManager = jWTManager;
            _userManager = userManager;
        }
        public async Task<Response<SignInResponse>> Login(SignInRequest request)
        {
            Response<SignInResponse> response = new Response<SignInResponse>();
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var tokens = _jwtManager.Authenticate(user, userRoles ?? new List<string>());

                response.Success = true;
                response.Message = "Login Successful";
                response.Data = new SignInResponse
                {
                    Tokens = tokens
                };

                return response;
            }

            response.Message = "Invalid Login Credentials";
            return response;
        }
    }
}
