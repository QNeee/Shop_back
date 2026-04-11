namespace Shop_back.Core.Abstractions
{
    public interface ISharesService
    {
        Task<List<SharesItem>> GetSharesProducts();
    }
}
