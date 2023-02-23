using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Queries;

public class GetAllStudentsQuery : IRequest<IList<Student>>
{
}