using AltenChallengeV1.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AltenChallengeV1.Persistence.Interfaces;

namespace AltenChallengeV1.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        AltenChallengeContext _context;

        public VehicleRepository(AltenChallengeContext context)
        {
            this._context = context;
        }

        public async Task<Vehicle> GetVehicle(string id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.VehicleID == id);
        }

        public void Save(Vehicle vehicle)
        {
            _context.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Remove(vehicle);
        }

        public async Task<List<Vehicle>> GetVehicles(){
            return await _context.Vehicles.ToListAsync();
        }

        //public async Task<QueryResult<Customer>> GetVehicles(CustomerQuery queryObj)
        //{
        //    var result = new QueryResult<Customer>();

        //    var query = _context.Customers
        //      .AsQueryable();

        //    query = query.ApplyFiltering(queryObj);

        //    var columnsMap = new Dictionary<string, Expression<Func<Customer, object>>>()
        //    {
        //        ["make"] = v => v.Model.Make.Name,
        //        ["id"] = v => v.Model.Name,
        //        ["customerName"] = v => v.ContactName
        //    };
        //    query = query.ApplyOrdering(queryObj, columnsMap);

        //    result.TotalItems = await query.CountAsync();

        //    query = query.ApplyPaging(queryObj);

        //    result.Items = await query.ToListAsync();

        //    return result;
        //}
    }
}
