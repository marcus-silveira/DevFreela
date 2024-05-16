using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infra.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _dbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public UserViewModel? GetUser(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(user => user.Id == id);
        return user is null ? null : new UserViewModel(user.FullName, user.Email);
    }

    public int Create(CreateUserInputModel inputModel)
    {
        var user = new User(inputModel.UserName, inputModel.Email, inputModel.BirthDate);
        _dbContext.Users.Add(user);
        return user.Id;
    }
}