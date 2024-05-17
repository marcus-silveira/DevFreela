using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infra.DataBase.Repositories;

public class SkillRepository(DevFreelaDbContext dbContext) : RepositoryBase<Skill>(dbContext), ISkillRepository
{
    public async Task<IList<Skill>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Skills.ToListAsync();
    }
}