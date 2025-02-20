using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CL.S00243021
{
    public interface ICustomer<T>
    {
        IEnumerable<T> GetAll();
        T GetCustomerByID(int id);
    }
}
