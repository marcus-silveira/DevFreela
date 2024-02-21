namespace DevFreela.Core.Entities;

public class ProjectComment : BaseEntity
{
    public ProjectComment(int idProject, string content, int idUser)
    {
        IdProject = idProject;
        Content = content;
        IdUser = idUser;
    }

    public string Content { get; }
    public int IdProject { get; }
    public int IdUser { get; }
    public DateTime CreatedAt { get; }
}