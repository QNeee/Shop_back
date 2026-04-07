using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Core.Abstractions.Items.Smarts
{
    public interface ISmartsRepository
    {
        Task<Guid> Create(SmartModel smart);
        Task<Guid> Delete(Guid id);
        Task<List<SmartModel>> Get();
        Task<Guid> Update(Guid id, Dictionary<string, string[]> smartImages);
    }
}