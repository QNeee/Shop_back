using Shop_back.Core.Models.Product;

namespace Shop_back.Contracts.Request.Product
{
    public record CreateProductRequest(
        Guid Id,
        string Title,
        string Description,
        Dictionary<string, string[]> Images,
        List<ProductModelVariant> Variants,
        string Type
    );
    public record UpdateProductImagesRequest(
      Dictionary<string, string[]> Images
  );
    public record UpdateProductMainInfoRequest(
         string Title,
         string Description
    );
    public record UpdateProductVariantsRequest(
         List<ProductModelVariant> Variants
    );
}
