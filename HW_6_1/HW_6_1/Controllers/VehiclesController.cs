using System.Threading.Tasks;
using HW_6_1.Core;
using HW_6_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HW_6_1.Controllers;

[ApiController]
[Route("vehicles")]
public class VehiclesController : ControllerBase
{
    private readonly ILogger<VehiclesController> _logger;
    private readonly IVehiclesRepository _vehiclesRepository;

    public VehiclesController(
        ILogger<VehiclesController> logger,
        IVehiclesRepository vehiclesRepository)
    {
        _logger = logger;
        _vehiclesRepository = vehiclesRepository;
    }
    [HttpGet]
    public async Task<Vehicle[]> GetVehiclesAsync()
    {
        _logger.LogInformation("GetVehicleAsync is executed");
        return await _vehiclesRepository.GetVehiclesAsync();
    }

    [HttpPost]
    public async Task CreateVehicleAsync([FromBody] Vehicle vehicle)
    {
        await _vehiclesRepository.CreateVehicleAsync(vehicle);
    }

    [HttpDelete("{modelName}")]
    public async Task CreateVehicleAsync(string moduleName)
    {
        await _vehiclesRepository.DeleteVehicleAsync(moduleName);
    }

    [HttpPut("{modelName}")]
    public async Task CreateVehicleAsync([FromBody] Vehicle vehicle, string moduleName)
    {
        await _vehiclesRepository.UpdateVehicleAsync(vehicle, moduleName);
    }
        
        
        
        

}
