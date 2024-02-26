namespace Mono.Repository.Common
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        IVehicleMakeRepository VehicleMake {  get; }
    }
}
