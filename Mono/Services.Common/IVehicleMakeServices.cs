using Model;
using Mono.DAL.Entities;

namespace Mono.Services.Common
{
    public interface IVehicleMakeServices
    {
        IQueryable<VehicleMakeEntity> GetAll();
        IQueryable<VehicleMakeEntity> GetAllSortedFiltered(String? sortOrder, string? searchString);
        IQueryable<VehicleMakeEntity> GetAllPaginated(IQueryable<VehicleMakeEntity> source, int page,int pageSize);
        Task<VehicleMakeEntity> GetByIdAsync(int id);
        Task UpdateAsync(VehicleMakeEntity entity);
        Task AddNewAsync(VehicleMakeEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
