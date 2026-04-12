using Shop_back.Core.Models.Shares;

namespace Shop_back.Core.Abstractions.Shares
{
    public interface ISharesService
    {
        Task<Guid> CreateShare(Share share);
        Task<List<SharesModel>> GetSharesProducts();
    }
}
