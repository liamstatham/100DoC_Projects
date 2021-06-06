using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var expected = new Product(2)
            {
                CurrentPrice = 30.00M,
                ProductDescription = "A very magical wand.",
                ProductName = "wand"
            };

            //act
            var actual = productRepository.Retrieve(2);
            //assert

            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);

        }
        [TestMethod()]
        public void SaveTestValid()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                CurrentPrice = 18.00M,
                ProductDescription = "Assorted Size",
                ProductName = "Sunflowers",
                HasChanges = true
            };
            //act
            var actual = productRepository.Save(updatedProduct);
            //assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void SaveTestMissingPrice()
        {
            //arrange
            var productRepository = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                CurrentPrice = null,
                ProductDescription = "Assorted Size",
                ProductName = "Sunflowers",
                HasChanges = true
            };
            //act
            var actual = productRepository.Save(updatedProduct);
            //assert
            Assert.AreEqual(false, actual);
        }


    }
}
