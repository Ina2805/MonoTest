using Microsoft.AspNetCore.Mvc;
using Service.Services;
using VehicleMake = Service.Models.VehicleMake;


namespace MVC.Controllers;

public class VehicleMakeController : Controller
{
    private readonly IVehicleService _vehicleService;

    public VehicleMakeController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    public async Task<IActionResult> Index(int page = 1, string searchString = "", string sortOrder = "")
    {
        const int pageSize = 10; 
        
        var vehicleMakes = await _vehicleService.GetVehicleMakes(page, pageSize, searchString, sortOrder);

        var allVehicleMakes = await _vehicleService.GetVehicleMakes(searchString);
        var totalPages = (int)Math.Ceiling((double)allVehicleMakes.Count() / pageSize);

        page = Math.Clamp(page, 1, totalPages);

        var viewModel = new VehicleMakeListViewModel
        {
            VehicleMakes = vehicleMakes,
            TotalVehicleMakes = allVehicleMakes.Count(),
            CurrentPage = page,
            PageSize = pageSize,
            TotalPages = totalPages,
            SearchString = searchString
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehicleMake vehicleMake)
    {
        if (!ModelState.IsValid)
        {
            return View(vehicleMake);
        }
        
        try
        {
            await _vehicleService.AddVehicleMakeAsync(vehicleMake);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Failed to write to the database.");
            return View(vehicleMake);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(id);
        

        if (vehicleMake == null)
        {
            return NotFound();
        }

        return View(vehicleMake);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(VehicleMake vehicleMake)
    {
        if (!ModelState.IsValid)
        {
            return View(vehicleMake);
        }
        
        await _vehicleService.UpdateVehicleMakeAsync(vehicleMake);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(id);

        if (vehicleMake == null)
        {
            return NotFound();
        }

        return View(vehicleMake);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
    {
        try
        {
            await _vehicleService.DeleteVehicleMakeAsync(id);
        } catch (Exception)
        {
            ViewBag.ErrorMessage = "Failed to delete Vehicle Make";
            return RedirectToAction("Delete", new {id});
        }

        return RedirectToAction("Index");
    }
}