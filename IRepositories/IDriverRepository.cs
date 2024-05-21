using MvcCrudApp.Models;

namespace MvcCrudApp.IRepositories;

public interface IDriverRepository
{
    Task<Driver?> CreateDriver(Driver driver);
    Task<Driver?> GetDriverById(Guid id);
    Task<List<Driver>> GetAllDrivers();
    Task<bool> UpdateDriver(Guid id, Driver driver);
    Task<bool> DeleteDriver(Guid id);
}