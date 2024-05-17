using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel?>
{
    private readonly IUserRepository _repository;
    public GetUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return user == null ? null : new UserViewModel(user.FullName, user.Email);
    }
}