using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<IList<Project>> GetAllAsync(CancellationToken cancellationToken);
    Task<Project?> GetByIdAsync(int id);
    Task AddAsync(Project project, CancellationToken cancellationToken);
    Task AddCommentAsync(ProjectComment projectComment, CancellationToken cancellationToken);
    Task SaveChangesAsync(Project project, CancellationToken cancellationToken);
}