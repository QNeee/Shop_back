
namespace Shop_back.DataAccess.Entities.Product
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Images { get; set; } = "{}";
        public string Type { get; set; } = string.Empty;
        public string Variants { get; set; } = "[]";  
    }
}
