using Shop_back.Core.Models.ShopItems;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsService
    {
        Task<Guid> CreateSmart(Smart smart);
        Task<Guid> DeleteSmart(Guid id);
        Task<List<Smart>> GetAllSmarts();
        Task<Guid> UpdateSmart(Guid id, string title, string description, int price);
    }
}