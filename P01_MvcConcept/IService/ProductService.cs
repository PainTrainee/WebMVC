﻿
using P01_MvcConcept.Settings;

namespace P01_MvcConcept.IService
{
    public class ProductService : IProductService
    {
        public List<Product> ProductList { get; set; }
        public ProductService()
        {
            ProductList = new List<Product>();
        }
        public void GenerateProduct(int number)
        {
            Random rand = new Random();
            var numberOfName = NameOfProduct.ProductName.Count;
            for (int i = 0; i < number; i++)
            {
                ProductList.Add(new Product
                {
                    Id = i,
                    Name = NameOfProduct.ProductName[rand.Next(numberOfName)] + i,
                    Price = rand.Next(10,201),
                    Amount = rand.Next(1,101),
                });
            }
        }

        public List<Product> GetProductAll()
        {
            return ProductList;
        }
    }
}
