using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Entities;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Api.DTOs;
using Api.Interfaces;

namespace Api.Controllers
{
  public class AccountController : ApiController
  {
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
      _context = context;
      _tokenService = tokenService;
    }

    [HttpPost("register")] // api/account/register?username=meow&password=password
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (await UserExists(registerDto.UserName)) return BadRequest("Username is already taken");

      using var hmac = new HMACSHA512();

      var user = new AppUser
      {
        UserName = registerDto.UserName.ToLower(),
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };//

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return new UserDto
      {
        UserName = user.UserName,
        Token = _tokenService.CreateToken(user)
      };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

      if (user == null) return Unauthorized();

      using var hmac = new HMACSHA512(user.PasswordSalt);

      var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (int i = 0; i < computedHash.Length; i++)
      {
        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
      }

      return new UserDto
      {
        UserName = user.UserName,
        Token = _tokenService.CreateToken(user)
      };
    }

    private async Task<bool> UserExists(string username)
    {
      return await _context.Users.AnyAsync(u => u.UserName == username.ToLower());
    }
  }
}