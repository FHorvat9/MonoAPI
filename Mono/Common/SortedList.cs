using Mono.DAL.Entities;

namespace Mono.Common
{
    public class SortedList
    {
        public static IEnumerable<VehicleMakeEntity> SortList(IEnumerable<VehicleMakeEntity> source, string sortOrder)
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
