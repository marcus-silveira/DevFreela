namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(DateTime birthDateTime, string fullName, string email)
    {
        FullName = fullName;
        Email = email;
        BirthDateTime = birthDateTime;
        Active = true;
        CreatedAt = DateTime.Now;
        Skills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
    }

    public string FullName { get; }
    public string Email { get; }
    public DateTime BirthDateTime { get; }
    public DateTime CreatedAt { get; }
    public bool Active { get; }
    public List<UserSkill> Skills { get; }
    public List<Project> OwnedProjects { get; set; }
    public List<Project> FreelanceProjects { get; set; }
}