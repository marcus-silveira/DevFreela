namespace DevFreela.Core.Entities;

public class Skill : BaseEntity
{
    public Skill(string description, DateTime createdAt)
    {
        Description = description;
        CreatedAt = createdAt;
    }

    public string Description { get; }
    public DateTime CreatedAt { get; set; }
}