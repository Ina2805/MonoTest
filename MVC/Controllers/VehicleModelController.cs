using Microsoft.AspNetCore.Mvc;
using MVC.Models.VehicleModel;
using Service.Models;
using Service.Services;

namespace MVC.Controllers;

public class VehicleModelController : Controller
{
    private readonly IVehicleService _vehicleService;

    public VehicleModelController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    public async Task<ViewResult> Index(int page = 1, string searchString = "", string sortOrder = "")
    {
        const int pageSize = 10;

        var vehicleModels = await _vehicleService.GetVehicleModels(page, pageSize, searchString, sortOrder);

        var allVehicleModels = await _vehicleService.GetVehicleModels(searchString);
        var totalPages = (int)Math.Ceiling((double)allVehicleModels.Count() / pageSize);

        page = Math.Clamp(page, 1, totalPages);

        var viewModel = new VehicleModelListViewModel
        {
            VehicleModels = vehicleModels,
            CurrentPage = page,
            SearchString = searchString,
            TotalPages = totalPages,
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");

        ViewBag.vehicleMakes = vehicleMakes;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehicleModel vehicleModel)
    {
        var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(vehicleModel.VehicleMakeId);
        
        if (vehicleMake == null)
        {
            ModelState.AddModelError("VehicleMakeId", "Vehicle make does not exist.");
            var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");
            ViewBag.vehicleMakes = vehicleMakes;
            return View(vehicleModel);
        }
        
        vehicleModel.VehicleMake = vehicleMake;
        vehicleModel.Abrv = vehicleMake.Abrv;

        ModelState.Clear();

        if (!TryValidateModel(vehicleModel, nameof(vehicleModel)))
        {
            var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");
            ViewBag.vehicleMakes = vehicleMakes;
            return View(vehicleModel);
        }

        await _vehicleService.UpdateVehicleModelAsync(vehicleModel);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var vehicleModel = await _vehicleService.GetVehicleModelByIdAsync(id);

        if (vehicleModel == null)
        {
            return NotFound();
        }

        var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");

        ViewBag.vehicleMakes = vehicleMakes;

        return View(vehicleModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(VehicleModel vehicleModel)
    {
        var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(vehicleModel.VehicleMakeId);
        
        if (vehicleMake == null)
        {
            ModelState.AddModelError("VehicleMakeId", "Vehicle make does not exist.");
            var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");
            ViewBag.vehicleMakes = vehicleMakes;
            return View(vehicleModel);
        }
        
        vehicleModel.VehicleMake = vehicleMake;
        vehicleModel.Abrv = vehicleMake.Abrv;

        ModelState.Clear();

        if (!TryValidateModel(vehicleModel, nameof(vehicleModel)))
        {
            var vehicleMakes = await _vehicleService.GetVehicleMakesAsync("");
            ViewBag.vehicleMakes = vehicleMakes;
            return View(vehicleModel);
        }

        await _vehicleService.UpdateVehicleModelAsync(vehicleModel);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicleModel = await _vehicleService.GetVehicleModelByIdAsync(id);

        if (vehicleModel == null)
        {
            return NotFound();
        }

        return View(vehicleModel);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
    {
        await _vehicleService.DeleteVehicleModelAsync(id);

        return RedirectToAction("Index");
    }
}