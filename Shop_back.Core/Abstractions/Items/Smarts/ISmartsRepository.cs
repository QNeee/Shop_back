using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsRepository
    {
        Task<Guid> Create(SmartModel smart);
        Task<Guid> Delete(Guid id);
        Task<List<SmartModel>> Get();
        Task<List<SmartModel>> GetSharesSmarts();
        Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateVariants(Guid id, List<SmartVariant> variants);
    }
}