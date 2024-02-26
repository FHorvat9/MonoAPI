using Model;
using Mono.Common;
using Mono.DAL.Entities;

namespace Mono.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMakeEntity>
    {
        IQueryable<VehicleMakeEntity> GetAllSortedFiltered(IQueryable<VehicleMakeEntity> source, string? sortOrder, string? searchString);
        IQueryable<VehicleMakeEntity> GetAllPaginated(IQueryable<VehicleMakeEntity> source, int page,int pageSize);

    }
}
