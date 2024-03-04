using Model;
using Mono.Common;
using Mono.DAL.Entities;

namespace Mono.Services.Common
{
    public interface IVehicleMakeServices
    {
        IEnumerable<VehicleMakeEntity> GetAll();
        IEnumerable<VehicleMakeEntity> GetAll(VehicleMakeFilterParams filter);
        
        Task<VehicleMakeEntity> GetByIdAsync(int id);
        Task UpdateAsync(VehicleMakeEntity entity);
        Task AddNewAsync(VehicleMakeEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
