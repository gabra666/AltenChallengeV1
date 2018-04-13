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
    public class CustomerRepository : ICustomerRepository
    {
        AltenChallengeContext context;

        public CustomerRepository(AltenChallengeContext context)
        {
            this.context = context;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(customer => customer.CustomerID == id);
        }

        public void Save(Customer customer)
        {
            context.Add(customer);
        }

        public void Delete(Customer customer)
        {
            context.Remove(customer);
        }

        public async Task<List<Customer>> GetCustomers(){
            return await context.Customers.ToListAsync();
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
