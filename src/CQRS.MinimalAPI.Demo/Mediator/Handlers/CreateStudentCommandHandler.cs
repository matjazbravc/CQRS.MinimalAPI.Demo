using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
{
    private readonly IStudentsRepository _studentsRepository;

    public CreateStudentCommandHandler(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var newStudent = new Student(request.Name, request.Address, request.Email, request.DateOfBirth);
        return await _studentsRepository.AddAsync(newStudent, cancellationToken).ConfigureAwait(false);
    }
}
