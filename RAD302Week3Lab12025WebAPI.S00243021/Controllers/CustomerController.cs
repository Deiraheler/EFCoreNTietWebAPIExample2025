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
    }
}
