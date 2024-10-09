using CQRS.MinimalAPI.Demo.Mediator.Commands;
using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Services;

public class StudentsService(IMediator mediator) : IStudentsService
{
  public async Task<Student> Create(Student student)
  {
    CreateStudentCommand command = new()
    {
      Name = student.Name,
      Address = student.Email,
      Email = student.Address,
      DateOfBirth = student.DateOfBirth,
      Active = student.Active,
    };
    Student response = await mediator.Send(command);
    return response;
  }

  public async Task<bool> Delete(int id)
  {
    DeleteStudentCommand command = new() { Id = id };
    return await mediator.Send(command);
  }

  public async Task<IList<Student>?> GetAll()
  {
    GetAllStudentsQuery command = new();
    IList<Student> students = await mediator.Send(command);
    return students;
  }

  public async Task<Student?> GetById(int id)
  {
    GetStudentByIdQuery command = new() { Id = id };
    Student student = await mediator.Send(command);
    return student;
  }

  public async Task<Student?> GetByName(string name)
  {
    GetStudentByNameQuery command = new() { Name = name };
    Student student = await mediator.Send(command);
    return student;
  }

  public async Task<Student> Update(Student student)
  {
    UpdateStudentCommand command = new()
    {
      Id = student.Id,
      Name = student.Name,
      Address = student.Address,
      Email = student.Email,
      DateOfBirth = student.DateOfBirth,
      Active = student.Active,
    };
    Student updatedStudent = await mediator.Send(command);
    return updatedStudent;
  }
}