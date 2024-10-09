using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class CreateStudentCommandHandler(IStudentsRepository studentsRepository) : IRequestHandler<CreateStudentCommand, Student>
{
  public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
  {
    var newStudent = new Student(request.Name, request.Address, request.Email, request.DateOfBirth);
    return await studentsRepository.AddAsync(newStudent, cancellationToken).ConfigureAwait(false);
  }
}
