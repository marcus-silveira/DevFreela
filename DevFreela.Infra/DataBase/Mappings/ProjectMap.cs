using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.DataBase.Mappings;

public class ProjectMap : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(75);
        
        builder.Property(p => p.Description)
            .IsRequired();
        
        builder.Property(p => p.IdClient)
            .IsRequired();

        builder.Property(p => p.IdFreelancer)
            .IsRequired();

        builder.Property(p => p.TotalCost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.StartedAt)
            .IsRequired(false);

        builder.Property(p => p.FinishedAt)
            .IsRequired(false);

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<int>();
        
        // Relationships
        builder.HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(p => p.Client)
            .WithMany(f => f.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Project)
            .HasForeignKey(p => p.IdProject)
            .OnDelete(DeleteBehavior.Cascade);
    }
}