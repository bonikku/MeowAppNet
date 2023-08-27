using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  public class BugController : ApiController
  {
    private readonly DataContext _context;
    public BugController(DataContext context)
    {
      _context = context;

    }


    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetSecret()
    {
      return "meow";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
      var thing = _context.Users.Find(-1);

      if (thing == null) return NotFound();

      return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
      var thing = _context.Users.Find(-1).ToString();

      return thing;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
      return BadRequest("400 BadRequest Server error");
    }
  }
}