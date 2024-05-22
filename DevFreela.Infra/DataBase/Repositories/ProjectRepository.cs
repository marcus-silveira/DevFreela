using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infra.DataBase.Repositories;

public class ProjectRepository(DevFreelaDbContext dbContext) : RepositoryBase<Project>(dbContext), IProjectRepository
{
    public async Task<IList<Project>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Projects.ToListAsync(cancellationToken);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _dbContext.Projects
            .Include(p => p.Freelancer)
            .Include(p => p.Client)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Project project, CancellationToken cancellationToken)
    {
        await _dbContext.Projects.AddAsync(project, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddCommentAsync(ProjectComment projectComment, CancellationToken cancellationToken)
    {
        await _dbContext.ProjectComments.AddAsync(projectComment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(Project project, CancellationToken cancellationToken)
    {
        _dbContext.Entry(project).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}