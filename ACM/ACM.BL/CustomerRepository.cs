using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);

            //temp hard coded data to return

            if (customerId == 1)
            {
                customer.EmailAddress = "bilbo@thehobbit.com";
                customer.FirstName = "Bilbo";
                customer.LastName = "Baggins";
            }
            return customer;
        }

        public bool Save(Customer customer)
        {
            return true;
        }
    }
}
