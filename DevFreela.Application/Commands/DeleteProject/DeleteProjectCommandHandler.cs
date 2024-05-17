using DevFreela.Infra.DataBase.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        project.Cancel();
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}