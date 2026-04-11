

using Shop_back.Core.Abstractions;

namespace Shop_back.Contracts.Response
{

    public class SmartsShares
    {
        public List<SharesItem> SharesSmarts { get; set; } = new List<SharesItem>();
    }
    public record GetSharesResponse(
       SmartsShares Smarts
    );
}
