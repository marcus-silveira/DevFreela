using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel createProject)
    {
        return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
    }


    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectModel createProject)
    {
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
    {
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        return NoContent();
    }
}