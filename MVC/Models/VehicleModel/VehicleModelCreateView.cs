using System.ComponentModel.DataAnnotations;

namespace MVC.Models.VehicleModel;

public class VehicleModelCreateView
{
    public List<Service.Models.VehicleMake> VehicleMakes { get; set; }
    public Service.Models.VehicleModel VehicleModel { get; set; }
}