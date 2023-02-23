using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class GetStudentByNameQueryHandler : IRequestHandler<GetStudentByNameQuery, Student?>
{
    private readonly IStudentsRepository _studentsRepository;

    public GetStudentByNameQueryHandler(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task<Student?> Handle(GetStudentByNameQuery request, CancellationToken cancellationToken)
    {
        return await _studentsRepository.GetByNameAsync(request.Name, cancellationToken).ConfigureAwait(false);
    }
}
