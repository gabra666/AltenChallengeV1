using System.Collections.Generic;
using System.Threading.Tasks;
using AltenChallengeV1.Model.Models;

namespace AltenChallengeV1.Persistence.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(int id);
        void Save(Customer customer);
        void Delete(Customer customer);
        Task<List<Customer>> GetCustomers();
        // Task<QueryResult<Customer>> GetCustomers(CustomerQuery filter);
    }
}