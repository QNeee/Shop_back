using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.items;
using Shop_back.Contracts.Response.Items;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items;

namespace Shop_back.Controllers.Items
{
    [ApiController]
    [Route("api/items/smarts")]
    public class SmartsController : ControllerBase
    {
        private readonly ISmartsService _service;

        public SmartsController(ISmartsService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllSmartsResponse>>> GetSmarts()
        {
            var smarts = await _service.GetAllSmarts();
            var response = smarts.Select(s => new GetAllSmartsResponse(s.Id, s.Title, s.Description, s.Price));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSmart([FromBody] CreateSmartRequest req)
        {
            var (smart, error) = Smart.Create(Guid.NewGuid(), req.Title, req.Description, req.Price);
            if (!string.IsNullOrWhiteSpace(error)) return BadRequest(error);
            var smartId = await _service.CreateSmart(smart);
            return Ok(smartId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmart(Guid id, [FromBody] CreateSmartRequest req)
        {
            string titleError = Smart.ValidateFeld(req.Title, "Title");
            string descError = Smart.ValidateFeld(req.Description, "Description");
            string priceError = Smart.ValidatePrice(req.Price);
            string error = string.Join("\n", titleError, descError, priceError);
            if (!string.IsNullOrWhiteSpace(error)) return BadRequest(error);
            var smartId = await _service.UpdateSmart(id, req.Title, req.Description, req.Price);
            return Ok(smartId);
        }
        [HttpDelete("{id:guid}")] 
        public async Task<ActionResult<Guid>> DeleteSmart(Guid id)
        {
            var smartId = await _service.DeleteSmart(id);
            return Ok(smartId);
        }
    }
}
