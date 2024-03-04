using Mono.DAL.Entities;

namespace Mono.Common
{
    public class PagedList
    {
        public static IEnumerable<VehicleMakeEntity> PaginateList(IEnumerable<VehicleMakeEntity> source, VehicleMakeFilterParams filter)
        {
            if (filter.Page <= 0 || filter.PageSize <= 0)
            {
                return source;
            }
            else
            {
                var count = source.Count();
                var pageCount = (int)Math.Ceiling((double)count / filter.PageSize);
                if (filter.Page > pageCount)
                {
                    filter.Page = pageCount;
                }
                var pagedVehicles = source.Skip((filter.Page - 1) * filter.PageSize)
                    .Take(filter.PageSize);

                return pagedVehicles;
            }
        }
    }
}
