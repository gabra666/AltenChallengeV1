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
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;
        private IMapper mapper;
        private IUnitOfWork unitOfWork;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = mapper.Map<CustomerDTO, Customer>(customerDTO);

            customerRepository.Save(customer);
            await unitOfWork.CompleteAsync();

            customer = await customerRepository.GetCustomer(customer.CustomerID);

            var result = mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO customerDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await customerRepository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            mapper.Map<CustomerDTO, Customer>(customerDTO, customer);

            await unitOfWork.CompleteAsync();

            customer = await customerRepository.GetCustomer(customer.CustomerID);
            var result = mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await customerRepository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            customerRepository.Delete(customer);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
             var customer = await customerRepository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Customer, CustomerDTO> (customer);
            return Ok(result);
        }

        [HttpGet("customers")]
        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customers = await customerRepository.GetCustomers();
            return mapper.Map<List<Customer>, List<CustomerDTO>>(customers);
        }
    }
}
