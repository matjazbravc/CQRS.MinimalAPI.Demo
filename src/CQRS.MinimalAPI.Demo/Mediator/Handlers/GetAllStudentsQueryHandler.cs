using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class GetAllStudentsQueryHandler(IStudentsRepository studentsRepository) : IRequestHandler<GetAllStudentsQuery, IList<Student>?>
{
  public async Task<IList<Student>?> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
  {
    return await studentsRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
  }
}