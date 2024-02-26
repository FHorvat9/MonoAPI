

using Model.Common;

namespace Model
{
    public class VehicleMakePOCO : IVehicleMake
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
