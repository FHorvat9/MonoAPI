using Autofac;
using Model;
using Model.Common;
using Mono.DAL.Entities;


namespace Mono.Model
{
    public class DIVehicleMake : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IVehicleMake>().As<VehicleMakePOCO>();
            

        }
    }
}
