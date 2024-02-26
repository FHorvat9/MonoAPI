using DAL;
using Model;
using Mono.Common;
using Mono.DAL.Entities;
using Mono.Repository.Common;

namespace Mono.Repository
{
    public class VehicleMakeRepository :  GenericRepository<VehicleMakeEntity> , IVehicleMakeRepository
    {
        
        public VehicleMakeRepository(VehicleMakeDBContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<VehicleMakeEntity> GetAllSortedFiltered(IQueryable<VehicleMakeEntity> source,string sortOrder, string searchString)
        {
            return FilteredList.createFilteredList(source, sortOrder, searchString);
            
        }
        public IQueryable<VehicleMakeEntity> GetAllPaginated(IQueryable<VehicleMakeEntity> source,int page,int pageSize)
        {
            
                return PaginatedList.createPaginatedList(source, page, pageSize);

            



        }
    }
}
