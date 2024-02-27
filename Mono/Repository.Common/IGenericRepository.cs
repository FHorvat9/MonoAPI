namespace Mono.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddNewAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
