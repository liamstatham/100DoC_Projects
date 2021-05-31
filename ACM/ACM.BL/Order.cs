using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        public Order()
        {

        }
        public Order(int orderId)
        {
            orderId = orderId;
        }
        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }

        // Retieve one order
        public Order Retrieve(int orderId)
        {
            return new Order();
        }

        //Retrieve all orders
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        // Save
        public bool Save()
        {
            return true;
        }

        //Validate
        public bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid; 
        }
    }
}
