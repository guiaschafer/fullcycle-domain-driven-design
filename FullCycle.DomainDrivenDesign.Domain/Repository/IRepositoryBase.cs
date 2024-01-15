namespace FullCycle.DomainDrivenDesign.Domain.Repository;

public interface IRepositoryBase<T>
{

    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T> GetFindAsync(string id);
    Task<IEnumerable<T>> GetAll();
}