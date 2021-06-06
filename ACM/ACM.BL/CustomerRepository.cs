using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        private AddressRepository addressRepository { get; set; }
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);

            //temp hard coded data to return

            if (customerId == 1)
            {
                customer.EmailAddress = "bilbo@thehobbit.com";
                customer.FirstName = "Bilbo";
                customer.LastName = "Baggins";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            }
            return customer;
        }

        public bool Save(Customer customer)
        {
            var success = true;
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
                    {
                        // call an insert stored proc
                    }
                    else
                    {
                        // call an update stored proc
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
