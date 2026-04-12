using Shop_back.Core.Abstractions.Shares;
using Shop_back.Core.Models.Shares;

namespace Shop_back.Contracts.Response.Shares
{

    public class ProductShares
    {
        public List<SharesModel> SharesSmarts { get; set; } = new List<SharesModel>();
    }
    public record GetSharesResponse(
       ProductShares Smarts
    );
}
