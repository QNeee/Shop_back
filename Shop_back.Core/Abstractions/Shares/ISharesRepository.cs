
using Shop_back.Core.Models.Shares;

namespace Shop_back.Core.Abstractions.Shares
{
    public interface ISharesRepository
    {
        Task<Guid> CreateShare(Share share);
        Task<List<SharesModel>>GetAllShares();
    }
}
