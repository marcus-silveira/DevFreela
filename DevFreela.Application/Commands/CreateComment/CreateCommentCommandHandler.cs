﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public CreateCommentCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.IdProject, request.IdUser, request.Content);
        await _repository.AddCommentAsync(comment, cancellationToken);
        return Unit.Value;
    }
}