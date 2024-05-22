using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);
        await _repository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}