namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
    public UserSkill(int idSkill, int idUser)
    {
        IdSkill = idSkill;
        IdUser = idUser;
    }
    public int IdSkill { get; private set; }
    public Skill Skill { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
}