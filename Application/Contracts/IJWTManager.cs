using Application.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IJWTManager
    {
        Tokens Authenticate(AppUser user, ICollection<string> userRoles);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
