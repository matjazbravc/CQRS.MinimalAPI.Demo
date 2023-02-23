using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace CQRS.MinimalAPI.Demo.Services.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Add a new entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Add a range of new entities
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(IEnumerable<TEntity>? entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count entities
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition</param>
    /// <param name="tracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, bool tracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Check if an entity exists
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition</param>
    /// <param name="tracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a <see cref="List{T}" /> using the <paramref name="predicate" /> as a
    /// Where clause and using <paramref name="selector" /> to return desire to columns.
    /// Takes an optional <paramref name="orderBy" />. Must be used with await!
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition</param>
    /// <param name="selector">The selector for projection</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="orderBy">A function to order elements</param>
    /// <param name="tracking"></param>
    /// <param name="cancellationToken"></param>
    /// <remarks>This method default no-tracking query</remarks>
    /// <example>
    /// Usage:
    /// <code>
    ///    var result = await GetAsync(
    ///    include: source => source
    ///        .Include(user => user.Employee),
    ///    selector: user => new UserDto
    ///    {
    ///        Username = user.Username,
    ///        Password = user.Password,
    ///        FirstName = user.Employee.FirstName,
    ///        LastName = user.Employee.LastName
    ///    },
    ///    orderBy: user => user
    ///        .OrderBy(user => user.Username)).ConfigureAwait(false);
    /// </code>
    /// </example>
    Task<IList<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, TResult>>? selector = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool tracking = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the first or default entity based on a predicate, orderby delegate and include delegate
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition</param>
    /// <param name="include">A function to include navigation properties</param>
    /// <param name="tracking"></param>
    /// <param name="cancellationToken"></param>
    /// <remarks>This method default no-tracking query</remarks>
    /// <example>
    /// Usage:
    /// <code>
    ///    var affiliate = await affiliateRepository.GetFirstOrDefaultAsync(
    ///        predicate: b => b.Id == id,
    ///        include: source => source
    ///            .Include(a => a.Branches)
    ///            .ThenInclude(a => a.Emails)
    ///            .Include(a => a.Branches)
    ///            .ThenInclude(a => a.Phones));
    /// 
    /// </code>
    /// </example>
    Task<TEntity?> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool tracking = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Save all the modifications for a certain entity.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SaveAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove an entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="tracking"></param>
    /// <returns></returns>
    bool Remove(TEntity entity, bool tracking = true);

    /// <summary>
    /// Remove entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update existing entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Updated entity</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}