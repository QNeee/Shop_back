

using Shop_back.Core.Models.Product.ProductShares;

namespace Shop_back.Core.Models.Product.ProductCatalog
{
    public class ProductCatalogModel : ProductSharesModel
    {
        public ProductOptions Options { get; set; } = new();
    }
}
