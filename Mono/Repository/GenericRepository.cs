using DAL;
using Microsoft.EntityFrameworkCore;
using Mono.Common;
using Mono.DAL.Entities;
using Mono.Repository.Common;


namespace Mono.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected VehicleMakeDBContext _dbContext;
        protected DbSet<T> _dbSet;
        public GenericRepository(VehicleMakeDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddNewAsync(T entity)
        {
            
                await _dbSet.AddAsync(entity);
          
             
             
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entiry = await _dbSet.FindAsync(id);
            if(entiry != null)
            {
               _dbSet.Remove(entiry);
                return true;
            }
            else { 
                return false; 
            }  
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

      

        public  async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {

            
            _dbSet.Update(entity);
            
        }
    }
}
