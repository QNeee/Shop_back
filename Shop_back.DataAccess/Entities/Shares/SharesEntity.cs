
using Shop_back.DataAccess.Entities.Product;

namespace Shop_back.DataAccess.Entities.Shares
{
    public class SharesEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }

        public string Discount { get; set; }  = string.Empty;

        public ProductEntity Product { get; set; } = null!;
    }
}
