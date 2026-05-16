using Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
