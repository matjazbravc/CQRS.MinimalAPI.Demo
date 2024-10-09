using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Queries;

public class GetStudentByIdQuery : IRequest<Student>
{
  public int Id { get; set; }
}