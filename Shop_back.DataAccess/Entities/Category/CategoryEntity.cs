
using Shop_back.DataAccess.Entities.Product;

namespace Shop_back.DataAccess.Entities.Category
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductEntity> Products { get; set; } = new();
    }
}
