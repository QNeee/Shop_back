using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Contracts.Request.items.Smart
{
    public record CreateSmartRequest(
        string Title,
        string Description,
        SmartVariantOptions[] Options,
        Dictionary<string, string[]> SmartImages
    );
    public record UpdateSmartRequest(
        Dictionary<string, string[]> SmartImages
    );
}
