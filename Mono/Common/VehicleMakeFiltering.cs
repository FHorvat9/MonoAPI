using Microsoft.IdentityModel.Tokens;
using Mono.DAL.Entities;
using System.Reflection.Metadata.Ecma335;


namespace Mono.Common
{
    public class VehicleMakeFiltering
    {

        public static IEnumerable<VehicleMakeEntity> CreateFilteredList(IEnumerable<VehicleMakeEntity> source, VehicleMakeFilterParams filter)
        {
            var vehicleListFiltered = FilteredList.FilterList(source, filter.SearchString);
            var vehicleListFilteredSorted = SortedList.SortList(vehicleListFiltered, filter.SortOrder);
            var vehicleListPaginated = PagedList.PaginateList(vehicleListFilteredSorted, filter);
            return vehicleListPaginated;

        }
    }
}

