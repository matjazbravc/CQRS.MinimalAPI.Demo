using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class DeleteStudentCommandHandler(IStudentsRepository studentsRepository) : IRequestHandler<DeleteStudentCommand, bool>
{
  public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
  {
    return await studentsRepository.RemoveAsync(request.Id, cancellationToken).ConfigureAwait(false);
  }
}