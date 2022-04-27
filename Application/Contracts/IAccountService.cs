﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAccountService
    {
        Task<Response<SignInResponse>> Login(SignInRequest request);
    }
}
