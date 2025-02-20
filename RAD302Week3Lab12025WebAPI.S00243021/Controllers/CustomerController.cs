using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAD302Week3Lab12025CL.S00243021;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPI.S00243021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer<Customer> _customerRepository;

        public CustomerController(ICustomer<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            ActivityAPIClient.Track(StudentID: "S00243021", StudentName: "Dmytro Severin", activityName: "Rad302 Week 3 Lab 1", Task: "Testing basic controller call");

            return _customerRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Customer Get(int id)
        {
            ActivityAPIClient.Track(StudentID: "S00243021", StudentName: "Dmytro Severin", activityName: "Rad302 Week 3 Lab 1", Task: "Testing Get Customer By ID Call");

            return _customerRepository.GetCustomerByID(id);
        }

        [HttpGet("CheckCustomerCredit/{id}/{amount}")]
        public bool CheckCustomerCredit(int id, double amount)
        {
            ActivityAPIClient.Track(StudentID: "S00243021", StudentName: "Dmytro Severin", activityName: "Rad302 Week 3 Lab 1", Task: "Testing Check Customer Credit Rating Call");

            var customer = _customerRepository.GetCustomerByID(id);

            if (customer == null)
            {
                return false;
            }

            return customer.CreditRating >= amount;
        }
    }
}
