using CQRS.MinimalAPI.Demo.Mediator.Queries;
using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using MediatR;

namespace CQRS.MinimalAPI.Demo.Mediator.Handlers;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IList<Student>?>
{
    private readonly IStudentsRepository _studentsRepository;

    public GetAllStudentsQueryHandler(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task<IList<Student>?> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _studentsRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
    }
}