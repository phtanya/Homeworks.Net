using HW_6_1.Models;
using System.Threading.Tasks;

namespace HW_6_1.Core
{
    public interface IVehiclesRepository
    {
        public Task<Vehicle[]> GetVehiclesAsync();
        public Task CreateVehicleAsync(Vehicle vehicle);
        public Task DeleteVehicleAsync(string modelName);
        public Task UpdateVehicleAsync(Vehicle vehicle, string modelName);

    }
}
