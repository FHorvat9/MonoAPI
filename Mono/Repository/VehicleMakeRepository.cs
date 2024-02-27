using DAL;
using Model;
using Mono.Common;
using Mono.DAL.Entities;
using Mono.Repository.Common;
using System.Drawing.Printing;
using System.Transactions;

namespace Mono.Repository
{
    public class VehicleMakeRepository :  GenericRepository<VehicleMakeEntity> , IVehicleMakeRepository
    {
        
        public VehicleMakeRepository(VehicleMakeDBContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<VehicleMakeEntity> GetAll(VehicleMakeFilter filter)
        {
            return FilteredList.createFilteredList(base.GetAll(), filter);
            
        }
       
    }
}
