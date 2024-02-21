namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
    public UserSkill(int idSkill, int idUser)
    {
        IdSkill = idSkill;
        IdUser = idUser;
    }

    public int IdUser { get; private set; }
    public int IdSkill { get; private set; }
}