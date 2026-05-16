using Dtos;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Data;
using Helpers;
using Microsoft.EntityFrameworkCore;
using CineReserve.Data;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly CineDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(CineDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<User> Register(RegisterDto dto)
{
    try
    {
        var user = new User
        {
            Username = dto.Username,
            PasswordHash = HashPassword(dto.Password),
            Role = dto.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
    catch (Exception ex)
    {
        Console.WriteLine("REGISTER ERROR: " + ex.Message);
        throw new Exception("Registration failed: " + ex.Message);
    }
}

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == dto.Username);

            if (user == null)
                throw new Exception("User not found");

            if (user.PasswordHash != HashPassword(dto.Password))
                throw new Exception("Invalid password");

            return _jwt.GenerateToken(user);
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
