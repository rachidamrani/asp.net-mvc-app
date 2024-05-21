using Microsoft.AspNetCore.Mvc;
using MvcCrudApp.IRepositories;
using MvcCrudApp.Models;

namespace MvcCrudApp.Controllers;

public class DriversController : Controller
{
    private readonly IDriverRepository _driverRepository;

    public DriversController(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    // Get the list of all available drivers
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _driverRepository.GetAllDrivers());
    }

    // Get the form to create a new driver
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Driver driver)
    {
        if (ModelState.IsValid)
        {
            Driver? createdDriver = await _driverRepository.CreateDriver(driver);

            if (createdDriver is null) TempData["fail"] = "Something went wrong while creating the driver";

            return RedirectToAction("Index");
        }

        return View("Create");
    }


    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _driverRepository.DeleteDriver(id);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        Driver? driver = await _driverRepository.GetDriverById(id);

        if (driver is null) return RedirectToAction("Index");

        return View(driver);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, [FromForm] Driver driver)
    {
        if(!ModelState.IsValid) return View("Update");

        var result = await _driverRepository.UpdateDriver(id, driver);

        if (!result)
        {
            TempData["message"] = "Failed to accomplish updating ... Please try again !";
        }

        return RedirectToAction("Index");
    }
}