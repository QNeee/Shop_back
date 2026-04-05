using Shop_back.Core.Models.ShopItems;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsRepository
    {
        Task<Guid> Create(Smart smart);
        Task<Guid> Delete(Guid id);
        Task<List<Smart>> Get();
        Task<Guid> Update(Guid id, string title, string description, int price);
    }
}