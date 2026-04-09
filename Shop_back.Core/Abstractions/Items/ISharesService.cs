

using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Core.Abstractions.Items
{
    public interface ISharesService
    {
        Task<List<SmartModel>> GetSharesSmarts();
    }
}
