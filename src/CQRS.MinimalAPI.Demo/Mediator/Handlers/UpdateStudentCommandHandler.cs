using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class UpdateStudentCommandHandler(IStudentsRepository studentsRepository) : IRequestHandler<UpdateStudentCommand, Student?>
{
  public async Task<Student?> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
  {
    Student student = new Student(request.Name, request.Address, request.Email, request.DateOfBirth, request.Active)
    {
      Id = request.Id
    };
    return await studentsRepository.UpdateAsync(student, cancellationToken).ConfigureAwait(false);
  }
}