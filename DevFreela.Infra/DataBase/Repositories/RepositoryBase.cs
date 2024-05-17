using DevFreela.Infra.DataBase.Context;

namespace DevFreela.Infra.DataBase.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    protected readonly DevFreelaDbContext _dbContext;

    protected RepositoryBase(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}