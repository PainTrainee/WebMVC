namespace P04_RelationDB.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
