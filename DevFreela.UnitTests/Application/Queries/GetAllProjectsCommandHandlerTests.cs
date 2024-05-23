using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectsCommandHandlerTests
{
    [Fact]
    public async Task ThreeProjectExists_Executed_ReturnThreeProjectsViewModels()
    {
        // Arrange
        var projectList = new List<Project>
        {
            new("Project Test 1", "this is a test project", 1, 2, 1500),
            new("Project Test 2", "this is a test project", 1, 2, 2000),
            new("Project Test 3", "this is a test project", 1, 2, 4000),
        };
        var projectRepository = new Mock<IProjectRepository>();
        projectRepository.Setup(p => p.GetAllAsync(CancellationToken.None)).ReturnsAsync(projectList);

        var query = new GetAllProjectsQuery("");
        var queryHandler = new GetAllProjectsQueryHandler(projectRepository.Object);

        // Act
        var sut = await queryHandler.Handle(query, CancellationToken.None);
        
        // Assert
        Assert.NotEmpty(sut);
        Assert.NotNull(sut);
        Assert.Equal(sut.Count, projectList.Count);
        projectRepository.Verify(p => p.GetAllAsync(CancellationToken.None).Result, Times.Once);
    }
}