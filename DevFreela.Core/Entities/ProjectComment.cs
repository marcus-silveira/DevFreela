namespace DevFreela.Core.Entities;

public class ProjectComment : BaseEntity
{
    public ProjectComment(int idProject, string content, int idUser)
    {
        IdProject = idProject;
        Content = content;
        IdUser = idUser;

        CreatedAt = DateTime.Now;
    }

    public string Content { get; private set; }
    public int IdProject { get; private set; }
    public int IdUser { get; private set; }
    public DateTime CreatedAt { get; private set; }
}