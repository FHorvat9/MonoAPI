using Model;
using Mono.Common;
using Mono.DAL.Entities;
using Mono.Repository.Common;
using Mono.Services.Common;

namespace Mono.Services
{
    public class VehicleMakeServices : IVehicleMakeServices
    {
        private IUnitOfWork _unitOfWork;
        public VehicleMakeServices(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewAsync(VehicleMakeEntity entity)
        {
            await _unitOfWork.VehicleMake.AddNewAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.VehicleMake.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IQueryable<VehicleMakeEntity> GetAll()
        {
            return _unitOfWork.VehicleMake.GetAll();
            
        }

        public IQueryable<VehicleMakeEntity> GetAll(VehicleMakeFilter filter)
        {
            return _unitOfWork.VehicleMake.GetAll(filter);
        }


        public async Task<VehicleMakeEntity> GetByIdAsync(int id)
        {
            return await _unitOfWork.VehicleMake.GetByIdAsync(id);
        }

        public async Task UpdateAsync(VehicleMakeEntity entity)
        {
            await _unitOfWork.VehicleMake.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();

        }

       
    }
}
