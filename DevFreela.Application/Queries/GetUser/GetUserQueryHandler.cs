using DevFreela.Application.ViewModels;
using DevFreela.Infra.DataBase.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel?>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetUserQueryHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id,
            cancellationToken);

        return user == null ? null : new UserViewModel(user.FullName, user.Email);
    }
}