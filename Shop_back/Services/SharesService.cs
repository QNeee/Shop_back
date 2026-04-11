using Shop_back.Core.Abstractions;
using Shop_back.Core.Abstractions.Product;

namespace Shop_back.Services
{
    public class SharesService : ISharesService
    {
        private readonly IProductService _productService;
        public SharesService(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<List<SharesItem>> GetSharesProducts()
        {
            return new List<SharesItem>();
        }
    }
}
