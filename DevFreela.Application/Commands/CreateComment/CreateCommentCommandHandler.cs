using DevFreela.Core.Entities;
using DevFreela.Infra.DataBase.Context;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.IdProject, request.IdUser, request.Content);

        await _dbContext.ProjectComments.AddAsync(comment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}