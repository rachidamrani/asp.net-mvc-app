using Microsoft.EntityFrameworkCore;
using MvcCrudApp.IRepositories;
using MvcCrudApp.Models;

namespace MvcCrudApp.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly AppContext _dbContext;
    private readonly ILogger<DriverRepository> _logger;

    public DriverRepository(AppContext dbContext, ILogger<DriverRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    public async Task<Driver?> CreateDriver(Driver driver)
    {
        try
        {
            _logger.LogInformation("Creating a new driver ..");
            _dbContext.Drivers.Add(driver);
            await _dbContext.SaveChangesAsync();

            return await GetDriverById(driver.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Something went wrong while creating the driver {driver.FirstName}");
            return null;
        }
    }

    public async Task<Driver?> GetDriverById(Guid id) => await _dbContext.Drivers.FindAsync(id);

    public async Task<List<Driver>> GetAllDrivers() => await _dbContext.Drivers.ToListAsync();

    public async Task<bool> UpdateDriver(Guid id, Driver driver)
    {
        try
        {
            if (id != driver.Id) return false;

            Driver? updateTarget = await GetDriverById(id);

            if (updateTarget is null) return false;

            updateTarget.FirstName = driver.FirstName;
            updateTarget.LastName = driver.LastName;
            updateTarget.Email = driver.Email;

            await _dbContext.SaveChangesAsync();
            
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Something went wrong while updating the driver with ID {id}");
            return false;
        }
    }

    public async Task<bool> DeleteDriver(Guid id)
    {
        try
        {
            Driver? driverToDelete = await GetDriverById(id);

            if (driverToDelete is null) return false;

            _dbContext.Drivers.Remove(driverToDelete);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Something went wrong while deleting the driver with ID {id}");
            return false;
        }
    }
}