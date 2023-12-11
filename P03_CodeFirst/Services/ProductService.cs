﻿using P03_CodeFirst.Data;
using P03_CodeFirst.Models;

namespace P03_CodeFirst.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _db;
        List<Product> ProductList;

        public ProductService(DataContext _db)
        {
            this._db = _db;
            ProductList  = new List<Product>();
            if (_db.Products.Count() == 0) GenerateProduct();
        }

        public void Delete(Product product)
        {
            _db.Products.Remove(product); // Memory
            _db.SaveChanges(); // Delete from Database
        }

        public void GenerateProduct(int number = 10)
        {
            Random rnd = new Random();
            for (int i = 0; i < number; i++)
            {
                ProductList.Add(new Product
                {
                    //Id = i,
                    Name = "Coffee"+i,
                    Price = rnd.Next(10,100),
                    Amount = rnd.Next(1,10),
                });
            }
            _db.Products.AddRange(ProductList); // In memory
            _db.SaveChanges(); // To disk
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }
    }
}
