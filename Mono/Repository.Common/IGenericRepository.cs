namespace Mono.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddNewAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
