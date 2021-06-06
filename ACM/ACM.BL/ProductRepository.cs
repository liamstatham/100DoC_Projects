using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            // temp hard coded
            if(productId == 2)
            {
                product.ProductName = "wand";
                product.ProductDescription = "A very magical wand.";
                product.CurrentPrice = 30.00M;
            }
            object myObject = new object();
            Console.WriteLine($"Object: {myObject.ToString()}");
            Console.WriteLine($"Product: {product.ToString()}");
            return product;
        }
        public bool Save(Product product)
        {
            var success = true;
            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
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
