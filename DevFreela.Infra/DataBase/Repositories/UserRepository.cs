using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infra.DataBase.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infra.DataBase.Repositories;

public class UserRepository(DevFreelaDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u != null && u.Id == id, cancellationToken);
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Password == passwordHash && u.Email == email,
                cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}