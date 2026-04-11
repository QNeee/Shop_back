
using Shop_back.DataAccess.Entities.Product;

namespace Shop_back.Contracts.Response.Product
{
    public record GetAllProductsResponse(
       Guid Id,
       string Title,
       string Description,
       List<ProductVariant> Variants,
       Dictionary<string, string[]> Images
   );
}
