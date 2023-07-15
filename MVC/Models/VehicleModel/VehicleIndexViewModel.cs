namespace MVC.Models.VehicleModel;

public class VehicleIndexViewModel
{
    public List<Service.Models.VehicleMake> VehicleMakes { get; set; }
    public Task<List<Service.Models.VehicleModel>> VehicleModels { get; set; }
}