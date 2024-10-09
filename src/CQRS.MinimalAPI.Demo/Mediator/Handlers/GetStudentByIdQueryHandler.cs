using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class GetStudentByIdQueryHandler(IStudentsRepository studentsRepository) : IRequestHandler<GetStudentByIdQuery, Student?>
{
  public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
  {
    return await studentsRepository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
  }
}
