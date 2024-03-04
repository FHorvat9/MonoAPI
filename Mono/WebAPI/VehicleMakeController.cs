using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Mono.Common;
using Mono.DAL.Entities;
using Mono.Repository.Common;
using Mono.Services.Common;

namespace Mono.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeServices _vehicleMakeServices;
        private readonly IMapper _mapper;
        public VehicleMakeController(IVehicleMakeServices vehicleMakeServices, IMapper mapper)
        {
            _vehicleMakeServices = vehicleMakeServices;
            _mapper = mapper;
        }

        [HttpGet("GetAllVehicleMakes")]
        public async Task<IActionResult> ReadAll()
        {
            
            var vehicles =  _vehicleMakeServices.GetAll();
            
            var vehiclesPOCO = _mapper.Map<IEnumerable<VehicleMakePOCO>>(vehicles);

            return Ok(vehiclesPOCO);
        }
        [HttpGet("GetAllVehicleMakesFiltered")]
        public async Task<IActionResult> ReadAll(string? sortOrder, string? searchString, int page, int pageSize)
        {
            VehicleMakeFilterParams filter = new VehicleMakeFilterParams();
            filter.SortOrder = sortOrder;
            filter.SearchString = searchString;
            filter.Page = page;
            filter.PageSize = pageSize;
            var vehicles = _vehicleMakeServices.GetAll(filter);
            var vehiclesPOCO = _mapper.Map<IEnumerable<VehicleMakePOCO>>(vehicles);

            return Ok(vehiclesPOCO);
        }







        [HttpGet("GetVehicleMakeById/{id:int}")]
        public async Task<IActionResult> ReadById(int id)
        {
            
            var vehicles = await _vehicleMakeServices.GetByIdAsync(id);
            var vehiclePOCO = _mapper.Map<VehicleMakePOCO>(vehicles);
            if (vehiclePOCO != null)
            {
                return Ok(vehiclePOCO);
            }
            return BadRequest();

           
        }

        [HttpDelete("VehicleMakes/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicles = await _vehicleMakeServices.GetByIdAsync(id);
            if (vehicles != null) {
                await _vehicleMakeServices.DeleteAsync(id);
                return Ok();

            }
            return BadRequest();


        }



        [HttpPost("CreateVehicleMake")]
        public async Task<IActionResult> Create(VehicleMakePOCO vehicleMake)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            vehicleMake.Id = 0;
            var vehicleEntity = _mapper.Map<VehicleMakeEntity>(vehicleMake);
            await _vehicleMakeServices.AddNewAsync(vehicleEntity);
            return Ok();
        }

        [HttpPut("UpdateVehicleMake/{id:int}")]
        public async Task<IActionResult> Update(int id,VehicleMakePOCO newVehicle)
        {
            var oldVehicle = await _vehicleMakeServices.GetByIdAsync(id);
            if (oldVehicle != null)
            {
                oldVehicle.Name = newVehicle.Name;
                oldVehicle.Abrv = newVehicle.Abrv;
                
                await _vehicleMakeServices.UpdateAsync(oldVehicle);
                return Ok();
            }
            return BadRequest();
        }
    }
}

