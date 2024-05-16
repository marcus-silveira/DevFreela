﻿using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
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

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateUserInputModel createUserModel)
    {
        var id = _userService.Create(createUserModel);

        return CreatedAtAction(nameof(GetById), new { id }, createUserModel);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent();
    }
}