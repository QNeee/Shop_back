using Shop_back.Core.Abstractions.Items;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Services
{
    public class SharesService : ISharesService
    {
        private readonly ISmartsRepository _smartsReposiroty;
        public SharesService(ISmartsRepository smartsReposiroty)
        {
            _smartsReposiroty = smartsReposiroty;
        }
        public Task<List<SharesItem>> GetSharesSmarts()
        {
            return _smartsReposiroty.GetSharesSmarts();
        }
    }
}
