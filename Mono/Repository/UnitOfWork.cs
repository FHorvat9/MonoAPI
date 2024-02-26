using DAL;

using Mono.Repository.Common;

namespace Mono.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleMakeDBContext _dbContext;
        public IVehicleMakeRepository VehicleMake { get; set; }
        public UnitOfWork(VehicleMakeDBContext dbContext )
        {
            _dbContext = dbContext;
            VehicleMake = new VehicleMakeRepository(dbContext);
        }

        

        public async Task<bool> SaveAsync()
        {
           return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
