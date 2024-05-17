using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<IList<Skill>> GetAllAsync(CancellationToken cancellationToken);
}