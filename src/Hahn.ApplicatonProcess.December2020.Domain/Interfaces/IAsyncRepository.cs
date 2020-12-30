namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;

    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
