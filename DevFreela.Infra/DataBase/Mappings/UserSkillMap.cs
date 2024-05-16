using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.DataBase.Mappings;

public class UserSkillMap : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.HasKey(us => new { us.IdUser, us.IdSkill });
        
        // Relationships
        builder.HasOne(us => us.User)
            .WithMany(u => u.Skills)
            .HasForeignKey(us => us.IdUser);

        builder.HasOne(us => us.Skill)
            .WithMany(s => s.UserSkills)
            .HasForeignKey(us => us.IdSkill);
    }
}