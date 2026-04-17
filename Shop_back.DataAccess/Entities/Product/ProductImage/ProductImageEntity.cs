namespace Shop_back.DataAccess.Entities.Product
{
    public class ProductImageEntity
    {
        public Guid ProductImageId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public Guid ProductId { get; set; }
        public string[] Urls { get; set; } = [];
        public string Color { get; set; } = string.Empty;
    }
}
