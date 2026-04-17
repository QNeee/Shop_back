
using Shop_back.Core.Models.Product;

namespace Shop_back.Contracts.Response.Product
{
    public record GetAllProductsResponse(
      List<ProductModel> Products
   );
    public record GetAllSharesProductResponse(
        
        );
}
