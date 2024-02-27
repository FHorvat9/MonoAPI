using Microsoft.IdentityModel.Tokens;
using Mono.DAL.Entities;
using System.Reflection.Metadata.Ecma335;


namespace Mono.Common
{
    public class FilteredList
    {


        public static IEnumerable<VehicleMakeEntity> createFilteredList(IEnumerable<VehicleMakeEntity> source, VehicleMakeFilter filter)
        {
            var VehicleListFiltered = GetAllVehicleMakesFiltered(source, filter.searchString);
            var VehicleListFilteredSorted = GetAllVehicleMakesSorted(VehicleListFiltered, filter.sortOrder);
            if (filter.page <= 0 || filter.pageSize <= 0)
            {
                return VehicleListFilteredSorted;
            }
            else { 
            return createPaginatedList(VehicleListFilteredSorted, filter);
        }
            
        }

        private static IEnumerable<VehicleMakeEntity> GetAllVehicleMakesFiltered(IEnumerable<VehicleMakeEntity> source, string searchString)
        {
            if (!searchString.IsNullOrEmpty())
            {
                return source.Where(e => e.Name.Contains(searchString) || e.Abrv.Contains(searchString));
            }
            return source;


        }
        private static  IEnumerable<VehicleMakeEntity> GetAllVehicleMakesSorted(IEnumerable<VehicleMakeEntity> source, string sortOrder)
        {
            if (sortOrder == null)
            {
                sortOrder = "";
            }

            switch (sortOrder)
            {
                case "nameDesc":
                    return source.OrderByDescending(e => e.Name);

                case "abrvDesc":
                    return source.OrderByDescending(e => e.Abrv);

                case "abrv":
                    return source.OrderBy(e => e.Abrv);
                default:

                    return source.OrderBy(e => e.Name);

            }
        }
        private static IEnumerable<VehicleMakeEntity> createPaginatedList(IEnumerable<VehicleMakeEntity> source, VehicleMakeFilter filter)
        {
            
            var count = source.Count();
            var pageCount = (int)Math.Ceiling((double)count / filter.pageSize);
            if (filter.page > pageCount)
            {
                filter.page = pageCount;
            }
            var pagedVehicles = source.Skip((filter.page - 1) * filter.pageSize)
                .Take(filter.pageSize);

            return pagedVehicles;
        }
    }
}
