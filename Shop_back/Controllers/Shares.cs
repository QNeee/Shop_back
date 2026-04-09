using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Response;
using Shop_back.Core.Abstractions.Items;

namespace Shop_back.Controllers
{
    [ApiController]
    [Route("api/shares")]
    public class Shares : ControllerBase
    {
        private readonly ISharesService _service;
        public Shares(ISharesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetSharesResponse>>> GetSharesSmarts()
        {
            var smarts = await _service.GetSharesSmarts();
            return Ok(smarts);
        }
    }
}
