using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltenChallengeV1.DTO;
using AltenChallengeV1.Model.Models;
using AltenChallengeV1.Persistence.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AltenChallengeV1.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private IVehicleRepository vehicleRepository;
        private IMapper mapper;
        private IUnitOfWork unitOfWork;

        public VehicleController(IVehicleRepository vehicleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleDTO, Vehicle>(vehicleDTO);

            vehicleRepository.Save(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await vehicleRepository.GetVehicle(vehicle.VehicleID);

            var result = mapper.Map<Vehicle, VehicleDTO>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(string id, [FromBody] VehicleDTO vehicleDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await vehicleRepository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            mapper.Map<VehicleDTO, Vehicle>(vehicleDTO, vehicle);

            await unitOfWork.CompleteAsync();

            vehicle = await vehicleRepository.GetVehicle(vehicle.VehicleID);
            var result = mapper.Map<Vehicle, VehicleDTO>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var vehicle = await vehicleRepository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicleRepository.Delete(vehicle);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(string id)
        {
             var vehicle = await vehicleRepository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Vehicle, VehicleDTO> (vehicle);
            return Ok(result);
        }

        [HttpGet("vehicles")]
        public async Task<IEnumerable<VehicleDTO>> GetVehicles()
        {
            var vehicles = await vehicleRepository.GetVehicles();
            return mapper.Map<List<Vehicle>, List<VehicleDTO>>(vehicles);
        }
    }
}
