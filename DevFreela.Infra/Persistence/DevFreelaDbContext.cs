using DevFreela.Core.Entities;

namespace DevFreela.Infra.Persistence;

public class DevFreelaDbContext
{
    public List<Project> Projects { get; set; } = new()
    {
        new Project("Project in ASP.NET", "Description", 1, 2, 11000),
        new Project("Project in Blazor", "Description", 1, 2, 27000)
    };

    public List<User> Users { get; set; } = new()
    {
        new User("Marcus Silveira", "marcus@email.com", new DateTime(2001, 11, 10)),
        new User("Robert C; Martin", "robert@email.com", new DateTime(1960, 11, 10))
    };

    public List<Skill> Skills { get; set; } = new()
    {
        new Skill("NodeJS"),
        new Skill("JS"),
        new Skill("Python"),
        new Skill("PHP")
    };

    public List<ProjectComment> ProjectComments { get; set; } = new()
    {
        new ProjectComment(1, 1, "The project was excellent"),
        new ProjectComment(1, 2, "Thank You")
    };
}