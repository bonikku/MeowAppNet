using Api.DTOs;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
public class UsersController : ApiController
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  public UsersController(IUserRepository userRepository, IMapper mapper)
  {
    _mapper = mapper;
    _userRepository = userRepository;

  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
  {
    var users = await _userRepository.GetMembersAsync();

    return Ok(users);
  }

  [HttpGet("{username}")]
  public async Task<ActionResult<MemberDto>> GetUser(string username)
  {
    return await _userRepository.GetMemberAsync(username);
  }
}
