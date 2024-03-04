using Microsoft.IdentityModel.Tokens;
using Mono.DAL.Entities;

namespace Mono.Common
{
    public class FilteredList
    {
        public static IEnumerable<VehicleMakeEntity> FilterList(IEnumerable<VehicleMakeEntity> source, string searchString)
        {
            if (!searchString.IsNullOrEmpty())
            {
                return source.Where(e => e.Name.Contains(searchString) || e.Abrv.Contains(searchString));
            }
            return source;


        }
    }
}
