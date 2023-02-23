using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Commands;

public class DeleteStudentCommand : IRequest<bool>
{
    public int Id { get; set; }
}