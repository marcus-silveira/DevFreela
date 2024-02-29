using DevFreela.Api.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUser(id);
        if (user is null) return NotFound();
        
        return Ok(user);
    }

    // api/users
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserInputModel inputModel)
    {
        var id = _userService.Create(inputModel);
        
        return CreatedAtAction(nameof(GetById), new { id = 1 }, inputModel);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent();
    }
}