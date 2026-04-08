using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Contracts.Request.items.Smart
{
    public record CreateSmartRequest(
        string Title,
        string Description,
        SmartVariantOptions[] Options,
        Dictionary<string, string[]> SmartImages
    );
    public record UpdateSmartImagesRequest(
        Dictionary<string, string[]> SmartImages
    );
    public record UpdateSmartMainInfoRequest(
         string Title,
         string Description
    );
    public record UpdateSmartVariantsRequest(
         List<SmartVariant> Variants
    );
}
