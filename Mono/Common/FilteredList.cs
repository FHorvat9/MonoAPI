using Microsoft.IdentityModel.Tokens;
using Mono.DAL.Entities;


namespace Mono.Common
{
    public class FilteredList
    {


        public static IQueryable<VehicleMakeEntity> createFilteredList(IQueryable<VehicleMakeEntity> source, string sortOrder, string searchString)
        {
            var VehicleListFiltered = GetAllVehicleMakesFiltered(source, searchString);
            var VehicleListFilteredSorted = GetAllVehicleMakesSorted(VehicleListFiltered, sortOrder);
            return VehicleListFilteredSorted;
        }

        private static IQueryable<VehicleMakeEntity> GetAllVehicleMakesFiltered(IQueryable<VehicleMakeEntity> source, string searchString)
        {
            if (!searchString.IsNullOrEmpty())
            {
                return source.Where(e => e.Name.Contains(searchString) || e.Abrv.Contains(searchString));
            }
            return source;


        }
        private static  IQueryable<VehicleMakeEntity> GetAllVehicleMakesSorted(IQueryable<VehicleMakeEntity> source, string sortOrder)
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
    }
}
