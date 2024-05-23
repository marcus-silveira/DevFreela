using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities;

public class ProjectTests
{
    [Fact]
    public void Start_StatusIsCreatedEqual_StartProject()
    {
        // Arrange
        var project = new Project("Project Test", "this is a test project", 1, 2, 1500);

        // Act
        project.Start();
        
        // Assert
        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);
    }
    
    [Fact]
    public void Start_StatusIsNotCreatedEqual_NotStartProject()
    {
        // Arrange
        var project = new Project("Project Test", "this is a test project", 1, 2, 1500);
        project.Start();
        project.Finish();
        
        // Act
        project.Start();
        
        // Assert
        Assert.NotEqual(ProjectStatusEnum.InProgress, project.Status);
        Assert.Equal(ProjectStatusEnum.Finished, project.Status);
    }
}