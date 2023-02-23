using CQRS.MinimalAPI.Demo.Models;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Commands;

public class CreateStudentCommand : IRequest<Student>
{
    public string Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Active { get; set; } = true;
}