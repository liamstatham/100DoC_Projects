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
            return product;
        }
        public bool Save()
        {
            return true;
        }
    }
}
