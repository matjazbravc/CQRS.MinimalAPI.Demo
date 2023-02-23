using CQRS.MinimalAPI.Demo.Models;
using CQRS.MinimalAPI.Demo.Services.Repositories.Base;

namespace CQRS.MinimalAPI.Demo.Services.Repositories;

public interface IStudentsRepository : IBaseRepository<Student>
{
    Task<IList<Student>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<Student?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}