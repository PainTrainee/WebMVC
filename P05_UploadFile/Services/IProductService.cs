namespace P05_UploadFile.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProduct();
        Task Add(Product product, IFormFile file);
        Task Update(Product product, IFormFile file);
        Task<Product> Find(int id);
        Task Delete(Product product);
    }
}
