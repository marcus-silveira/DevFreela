using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.DataBase.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();
        
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.BirthDate)
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(u => u.Active)
            .IsRequired();
        
        // Relationships
        builder.HasMany(u => u.Skills)
            .WithOne(s => s.User)
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(u => u.OwnedProjects)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(u => u.FreelanceProjects)
            .WithOne(p => p.Freelancer)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(u => u.IdUser)
            .OnDelete(DeleteBehavior.Cascade);

    }
}