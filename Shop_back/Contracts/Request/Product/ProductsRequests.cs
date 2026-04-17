using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductVariant;

namespace Shop_back.Contracts.Request.Product
{
    public record CreateProductRequest(
        string ProductName,
        int CategoryId,
        ProductOptions Options,
        Dictionary<string, string[]> Images,
        List<ProductVariantModel> Variants
    );
    public record UpdateProductImagesRequest(
      Dictionary<string, string[]> Images
  );
    public record UpdateProductOptionsRequest(
     ProductOptions Options
 );
    public record UpdateProductMainInfoRequest(
         string ProductName,
         int CategoryId
    );
    public record UpdateProductVariantsRequest(
         List<ProductVariantModel> Variants
    );
    public record UpdateProductVariantRequest(
         Guid ProductVariantId,
         ProductVariantModel Variant
    );
}
