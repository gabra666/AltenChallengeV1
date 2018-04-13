using System.Collections.Generic;
using System.Threading.Tasks;
using AltenChallengeV1.Model.Models;

namespace AltenChallengeV1.Persistence.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(string id);
        void Save(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        Task<List<Vehicle>> GetVehicles();
        // Task<VehicleResult<Vehicle>> GetVehicles(VehicleQuery filter);
    }
}