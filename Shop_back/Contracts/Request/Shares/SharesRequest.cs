using Shop_back.Core.Models.Shares;

namespace Shop_back.Contracts.Request.Shares
{
    public record CreateShareRequset(
        Guid ProductId,
        Guid VariantId,
        Discount Discount
        );
}
