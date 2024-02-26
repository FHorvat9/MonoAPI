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
            
            
            return Ok(vehicles);
        }

        [HttpGet("GetAllVehicleMakesFiltered")]
        public async Task<IActionResult> ReadAllFiltered(string sortOrder="", string searchString="")
        {
          var vehicles =  _vehicleMakeServices.GetAllSortedFiltered(sortOrder, searchString);
          return Ok(vehicles);
        }

        [HttpGet("GetAllVehicleMakesFilteredPaginated")]
        public async Task<IActionResult> ReadAllFilteredPaginated(string sortOrder = "", string searchString = "", int page = 1,int pageSize = 5)
        {
            var vehicles =  _vehicleMakeServices.GetAllSortedFiltered(sortOrder, searchString);
            
            return Ok(_vehicleMakeServices.GetAllPaginated(vehicles,page, pageSize));
        }





        [HttpGet("GetVehicleMakeById/{id:int}")]
        public async Task<IActionResult> ReadById(int id)
        {
            
            var vehicles = await _vehicleMakeServices.GetByIdAsync(id);
            if (vehicles != null)
            {
                return Ok(vehicles);
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

