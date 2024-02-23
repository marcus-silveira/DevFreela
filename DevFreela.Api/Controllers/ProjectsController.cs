using DevFreela.Api.Models;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectService.GetAll(query);
        return Ok(projects);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);
        if (project is not null) return Ok(project);

        return NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel createProject)
    {
        return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
    }


    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] CreateProjectModel createProject)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }

    // api/projects/1/comments POST
    [HttpPost("{id:int}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
    {
        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id:int}/start")]
    public IActionResult Start(int id)
    {
        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id:int}/finish")]
    public IActionResult Finish(int id)
    {
        return NoContent();
    }
}