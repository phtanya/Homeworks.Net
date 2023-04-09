using HW_6_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW_6_1.Core
{
    public sealed class VehicleRepository : IVehiclesRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                ModelName = "300SL Gullwing",
                Brand = "Mercedes",
                ModelYear = 1954
            },
            new Vehicle
            {
                ModelName = "911",
                Brand = "Porsche",
                ModelYear = 1963
            },
            new Vehicle
            {
                ModelName = "GT350",
                Brand = "Ford Mustang",
                ModelYear = 1965
            }
        };
        public Task CreateVehicleAsync(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            return Task.CompletedTask;
        }

        public Task DeleteVehicleAsync(string modelName)
        {
            var index = _vehicles.FindIndex(x => x.ModelName == modelName);
            if (index == -1) 
            {
                return Task.CompletedTask;
            }
            _vehicles.RemoveAt(index);
            return Task.CompletedTask;
        }

        public Task<Vehicle[]> GetVehiclesAsync()
        {
            return Task.FromResult(_vehicles.ToArray());
        }

        public Task UpdateVehicleAsync(Vehicle vehicle, string modelName)
        {
            var index = _vehicles.FindIndex(x => x.ModelName == modelName);
            if (index == -1)
            {
                return Task.CompletedTask;
            }
            _vehicles.RemoveAt(index);
            _vehicles.Add(vehicle);
            return Task.CompletedTask;
        }
    }
}
