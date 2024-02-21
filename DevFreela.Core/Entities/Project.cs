namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;

        CreatedAt = DateTime.Now;
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComment>();
    }

    public string Title { get; }
    public string Description { get; set; }
    public int IdClient { get; }
    public int IdFreelancer { get; }
    public decimal TotalCost { get; }
    public DateTime CreatedAt { get; }
    public DateTime? StartedAt { get; }
    public DateTime? FinishedAt { get; }
    public ProjectStatusEnum Status { get; }
    public List<ProjectComment> Comments { get; }
}