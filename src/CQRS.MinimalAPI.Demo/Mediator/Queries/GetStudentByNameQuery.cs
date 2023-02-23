using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Queries;

public class GetStudentByNameQuery : IRequest<Student>
{
    public string Name { get; set; }
}