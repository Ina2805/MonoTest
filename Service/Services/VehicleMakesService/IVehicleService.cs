using Service.Models;

namespace Service.Services;

public interface IVehicleService
{
    Task<List<VehicleMake?>> GetVehicleMakesAsync(string searchString);
    Task<VehicleMake?> GetVehicleMakeByIdAsync(int id);
    Task AddVehicleMakeAsync(VehicleMake vehicleMake);
    Task UpdateVehicleMakeAsync(VehicleMake? vehicleMake);
    Task DeleteVehicleMakeAsync(int id);
    Task<List<VehicleMake?>> GetVehicleMakes(int page, int pageSize, string searchString, string sortOrder);
    Task<List<VehicleMake?>> GetVehicleMakes(string searchString);

    Task<List<VehicleModel>> GetVehicleModels(int page, int pageSize, string searchString, string sortOrder);
    Task<List<VehicleModel>> GetVehicleModels(string searchString);
    Task<VehicleModel?> GetVehicleModelByIdAsync(int id);
    Task UpdateVehicleModelAsync(VehicleModel vehicleModel);
    Task DeleteVehicleModelAsync(int id);
}