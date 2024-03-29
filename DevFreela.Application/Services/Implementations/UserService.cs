using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

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
        var user = _dbContext.Users.SingleOrDefault(user => user.Id == id);
        if (user is null) return null;
        
        var userViewModel = new UserViewModel(user.FullName, user.Email);

        return userViewModel;
    }

    public int Create(CreateUserInputModel inputModel)
    {
        var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDateTime);
        _dbContext.Users.Add(user);

        return user.Id;
    }
}