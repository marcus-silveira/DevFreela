namespace DevFreela.Application.InputModels;

public class CreateUserInputModel
{
    public CreateUserInputModel(string fullName, string email, DateTime birthDateTime)
    {
        FullName = fullName;
        Email = email;
        BirthDateTime = birthDateTime;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDateTime { get; private set; }
}