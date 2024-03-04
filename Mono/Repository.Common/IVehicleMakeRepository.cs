using Model;
using Mono.Common;
using Mono.DAL.Entities;

namespace Mono.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMakeEntity>
    {
        IEnumerable<VehicleMakeEntity> GetAllVehicleMakes(VehicleMakeFilterParams filter);
       
    }
}
