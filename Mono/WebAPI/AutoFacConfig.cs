using Autofac;
using Mono.Repository.Common;
using Mono.Repository;
using Mono.Services.Common;
using Mono.Services;

namespace Mono.WebAPI
{
    public class AutoFacConfig : Module
    {
        protected override void Load(ContainerBuilder builder) {

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<VehicleMakeServices>().As<IVehicleMakeServices>();
        }


    }
}
