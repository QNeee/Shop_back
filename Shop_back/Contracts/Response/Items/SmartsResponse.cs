using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Contracts.Response.Items
{
    public record GetAllSmartsResponse(
        Guid Id,
        string Title,
        string Description,
        List<SmartVariant>  SmartVariants
    );

}
