namespace DevFreela.Core.Entities;

public class ProjectComment : BaseEntity
{
    public ProjectComment(int idProject, int idUser, string content)
    {
        IdProject = idProject;
        Content = content;
        IdUser = idUser;

        CreatedAt = DateTime.Now;
    }

    public string Content { get; private set; }
    public int IdProject { get; private set; }
    public Project Project { get; set; }
    public int IdUser { get; private set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; private set; }
}