
using Shop_back.Core.Abstractions.Shares;
using Shop_back.Core.Models.Shares;

namespace Shop_back.Services.Shares
{
    public class SharesService : ISharesService
    {
        private readonly ISharesRepository _sharesRepository;
        public SharesService(ISharesRepository sharesRepository)
        {
            _sharesRepository = sharesRepository;
        }

        public async Task<Guid> CreateShare(Share share)
        {
            return await _sharesRepository.CreateShare(share);
        }

        public async Task<List<SharesModel>> GetSharesProducts()
        {
            return await _sharesRepository.GetAllShares();
        }
    }
}
