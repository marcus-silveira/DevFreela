using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infra.DataBase.Mappings;

public class ProjectCommentMap : IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject);

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser);    }
}