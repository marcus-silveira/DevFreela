namespace DevFreela.Application.ViewModels;

public class ProjectDetailsViewModel
{
    public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt,
        DateTime? finishedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
    }

    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public decimal TotalCost { get; }
    public DateTime? StartedAt { get; }
    public DateTime? FinishedAt { get; }
}