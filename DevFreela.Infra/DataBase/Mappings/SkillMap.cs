using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.DataBase.Mappings;

public class SkillMap : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(u => u.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Description)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");
    }
}