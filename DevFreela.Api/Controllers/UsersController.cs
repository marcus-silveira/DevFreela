using DevFreela.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    public UsersController(ExampleClass exampleClass)
    {
        // exampleClass.Name = "Update at UsersController";
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    // api/users
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel createUserModel)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent();
    }
}