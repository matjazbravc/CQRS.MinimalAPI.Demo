using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class GetStudentByNameQueryHandler(IStudentsRepository studentsRepository) : IRequestHandler<GetStudentByNameQuery, Student?>
{
  public async Task<Student?> Handle(GetStudentByNameQuery request, CancellationToken cancellationToken)
  {
    return await studentsRepository.GetByNameAsync(request.Name, cancellationToken).ConfigureAwait(false);
  }
}
