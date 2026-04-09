using Shop_back.Contracts.Response.Items;

namespace Shop_back.Contracts.Response
{
    public class SmartsShares
    {
        public List<GetAllSmartsResponse> Smarts { get; set; }  = new List<GetAllSmartsResponse>();
    }
    public record GetSharesResponse(
       SmartsShares SmartsShares
    );
}
