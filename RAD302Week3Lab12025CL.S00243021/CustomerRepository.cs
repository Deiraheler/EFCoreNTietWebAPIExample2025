using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CL.S00243021
{
    public class CustomerRepository : ICustomer<Customer>
    {
        private readonly CustomerDBContext _context;

        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerByID(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.ID == id);
        }
    }
}
