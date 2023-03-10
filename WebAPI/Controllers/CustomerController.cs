using CustomerEntities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private CustomerEntities.CustomerEntities _entities;

        public CustomerController(CustomerEntities.CustomerEntities entities) {
            _entities = entities; 
        }

        [HttpGet("")]
        public string Hello() {
            return "Hello from Customer Controller.";
        }

        [HttpGet("userids")]
        public string GetAllCustomers()
        
        {
            var ids = _entities.Customer.Select(c => c.Id).ToList();
            var sb = new StringBuilder();
            foreach (var id in ids)
            {
                sb.AppendLine(id.ToString());
            }
            return sb.ToString();
        }

        // Get Method to get all the deatils of the all Customers

        [HttpGet("customer_details")]

        public async Task<IActionResult> GetCustomer()
        {
            return Ok(await _entities.Customer.ToListAsync());

        }


        // get Customer by id Method

        [HttpGet("customer_by_id/{id}")]
        public async Task<IActionResult> getContact([FromRoute] int id)
        {
            var contact = await _entities.Customer.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        //public string GetCustomerDetails()
        //{
        //    var _fname = _entities.Customer.Select(_a => _a.FirstName).ToList();
        //    var _lname = _entities.Customer.Select(_b => _b.LastName).ToList();
        //    var sb = new StringBuilder();
        //    //List<_entities.Customer> = new List<_entities.Customer> ;
        //    foreach (var fname in _fname)
        //    {
        //        sb.AppendLine(fname);
        //    }
        //    return sb.ToString();

        //}


        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomer addcustomer)
        {
            var Customer = new Customer()
            {
                Id = addcustomer.Id,
                FirstName = addcustomer.FirstName,
                LastName = addcustomer.LastName,
                AddressId = addcustomer.AddressId,
            };
            await _entities.Customer.AddAsync(Customer);
            await _entities.SaveChangesAsync();
            return Ok(Customer);
        }

        [HttpPut("UpdateCustomer/{Id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int Id, UpdateCustomer updateCustomerReq)
        {
            var customer = await _entities.Customer.FindAsync(Id);
            if (customer != null)
            {
                customer.FirstName = updateCustomerReq.FirstName;
                customer.LastName = updateCustomerReq.LastName;
                customer.AddressId = updateCustomerReq.AddressId;
                customer.Id = updateCustomerReq.Id;
                _entities.SaveChanges();
                return Ok(customer);
            }
            return NotFound();  
        }

        [HttpDelete("DeleteCustomer/{Id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int Id)
        {
            var customer = await _entities.Customer.FindAsync(Id);
            if(customer != null)
            {
                _entities.Remove(customer);
                await _entities.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();

        }


    }
}
