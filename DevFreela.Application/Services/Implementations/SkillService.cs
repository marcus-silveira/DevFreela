﻿using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infra.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;

    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _dbContext.Skills;

        var skillsViewModel = skills
            .Select(skill => new SkillViewModel(skill.Id, skill.Description))
            .ToList();
        return skillsViewModel;
    }
}