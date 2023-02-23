using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Services;

public class StudentsService : IStudentsService
{
    private readonly IMediator _mediator;

    public StudentsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Student> Create(Student student)
    {
        var command = new CreateStudentCommand()
        {
            Name = student.Name,
            Address = student.Email,
            Email = student.Address,
            DateOfBirth = student.DateOfBirth,
            Active = student.Active,
        };
        Student response = await _mediator.Send(command);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        var command = new DeleteStudentCommand { Id = id };
        return await _mediator.Send(command);
    }

    public async Task<IList<Student>?> GetAll()
    {
        var command = new GetAllStudentsQuery();
        IList<Student> students = await _mediator.Send(command);
        return students;
    }

    public async Task<Student?> GetById(int id)
    {
        var command = new GetStudentByIdQuery { Id = id };
        Student student = await _mediator.Send(command);
        return student;
    }

    public async Task<Student?> GetByName(string name)
    {
        var command = new GetStudentByNameQuery { Name = name };
        Student student = await _mediator.Send(command);
        return student;
    }

    public async Task<Student> Update(Student student)
    {
        var command = new UpdateStudentCommand()
        {
            Id = student.Id,
            Name = student.Name,
            Address = student.Address,
            Email = student.Email,
            DateOfBirth = student.DateOfBirth,
            Active = student.Active,
        };
        Student updatedStudent = await _mediator.Send(command);
        return updatedStudent;
    }
}