using Microsoft.EntityFrameworkCore;
using Mono.DAL.Entities;

namespace Mono.Common
{
    public class PaginatedList {

        public static IQueryable<VehicleMakeEntity> createPaginatedList(IQueryable<VehicleMakeEntity> source, int page, int pageSize)
        {
            var count = source.Count();
            var pageCount = (int)Math.Ceiling((double)count / pageSize);
            if (page > pageCount)
            {
                page = pageCount;
            }
            var pagedVehicles = source.Skip((page - 1) * pageSize)
                .Take(pageSize);
                
            return pagedVehicles;
        }

    }
}
