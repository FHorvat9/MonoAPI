using AutoMapper;
using Model;
using Mono.DAL.Entities;

namespace Mono.WebAPI
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<VehicleMakeEntity, VehicleMakePOCO>().ReverseMap();
            
        }
    }
}

