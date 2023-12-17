﻿
using Microsoft.EntityFrameworkCore;
using P05_UploadFile.Settings;

namespace P05_UploadFile.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext dataContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductService(DataContext dataContext,IWebHostEnvironment webHostEnvironment)
        {
            this.dataContext = dataContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task Add(Product product, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            if (file != null) 
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName); // .jpg

                var folders = Path.Combine(wwwRootPath, Paths.Images); //ต่อไฟล์โดยใส่ \ ให้ด้วย
                var externalFile = Path.Combine(folders, fileName + extension); // ตัวไฟล์จริง
                var fileInDatabase = fileName + extension;// ชื่อ

                if (!Directory.Exists(folders)) Directory.CreateDirectory(folders);

                using (var fileStreams = new FileStream(externalFile, FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                product.ImageUrl = fileInDatabase;
            }
            await dataContext.Products.AddAsync(product);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            if (!String.IsNullOrEmpty(product.ImageUrl))
            {
                var fileDelete = Path.Combine(webHostEnvironment.WebRootPath, Paths.Images, product.ImageUrl);
                File.Delete(fileDelete);
            }
            dataContext.Products.Remove(product);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Product> Find(int id)
        {
            var product = await dataContext.Products.FindAsync(id);
            if (!String.IsNullOrEmpty(product.ImageUrl))
            {
                product.ImageUrl = Path.Combine("\\", Paths.Images, product.ImageUrl);
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            var products = await dataContext.Products.ToListAsync();
            products.ForEach(product =>
            {
                product.ImageUrl = !String.IsNullOrEmpty(product.ImageUrl) ? Path.Combine(Paths.Images, product.ImageUrl) : "Obsolete.png";
            });
            return products;
        }

        public async Task Update(Product product, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName); // .jpg

                var folders = Path.Combine(wwwRootPath, Paths.Images); //ต่อไฟล์โดยใส่ \ ให้ด้วย
                var externalFile = Path.Combine(folders, fileName + extension); // ตัวไฟล์จริง
                var fileInDatabase = fileName + extension;// ชื่อ

                if (!Directory.Exists(folders)) Directory.CreateDirectory(folders);

                using (var fileStreams = new FileStream(externalFile, FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                if (!String.IsNullOrEmpty(product.ImageUrl))
                {
                    var fileDelete = webHostEnvironment.WebRootPath + product.ImageUrl;
                    if (File.Exists(fileDelete)) File.Delete(fileDelete);
                }
                product.ImageUrl = fileInDatabase;
            }
            dataContext.Products.Update(product);
            await dataContext.SaveChangesAsync();
        }
    }
}
