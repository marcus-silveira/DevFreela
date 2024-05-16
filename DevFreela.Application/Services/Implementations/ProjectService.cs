﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infra.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _dbContext.Projects;

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }

    public ProjectDetailsViewModel? GetById(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(project => project.Id == id);
        if (project is null) return null;

        return new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost,
            project.StartedAt, project.FinishedAt);
    }

    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient,
            inputModel.IdFreelancer, inputModel.TotalCost);

        _dbContext.Projects.Add(project);

        return project.Id;
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }

    public void Delete(int id)
    {
        var project = _dbContext.Projects.SingleOrDefault(project => project.Id == id);
        project.Cancel();
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.IdProject, inputModel.IdUser, inputModel.Content);
        _dbContext.ProjectComments.Add(comment);
    }

    public void Start(int id)
    {
        var project = _dbContext.Projects.SingleOrDefault(project => project.Id == id);
        project.Start();
    }

    public void Finish(int id)
    {
        var project = _dbContext.Projects.SingleOrDefault(project => project.Id == id);
        project.Finish();
    }
}