using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.items.Smart;
using Shop_back.Contracts.Response.Items;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.Core.Models.Items.Smart;

namespace Shop_back.Controllers.Items
{
    [ApiController]
    [Route("api/items/smarts")]
    public class SmartsController : ControllerBase
    {
        private readonly ISmartsService _service;
        private readonly IValidator<CreateSmartRequest> _validator;

        public SmartsController(ISmartsService service, IValidator<CreateSmartRequest> validator)
        {
            _service = service;
            _validator = validator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllSmartsResponse>>> GetSmarts()
        {
            var smarts = await _service.GetAllSmarts();
            var response = smarts.Select(s => new GetAllSmartsResponse(s.Id, s.Title, s.Description, s.Variants, s.SmartImages));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSmart([FromBody] CreateSmartRequest req)
        {
            var validationResult = await _validator.ValidateAsync(req);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new { errors });
            }
            var options = req.Options
                .Select(o => new SmartVariantOptions(
                    o.Stock,
                    o.Memory,
                    o.Storage,
                    o.Price,
                    o.Discount
                ))
                .ToArray();

            var smart = new SmartModel(req.Title, req.Description, options);

            var smartId = await _service.CreateSmart(smart);

            return Ok(smartId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmart(Guid id, [FromBody] UpdateSmartRequest req)
        {

            var smartId = await _service.UpdateSmartImages(id, req.SmartImages);
            return Ok(smartId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSmart(Guid id)
        {
            var smart = await _service.GetSmartById(id);
            if (smart == null) return NotFound($"smart with id {id} not found");
            var smartId = await _service.DeleteSmart(id);
            return Ok(smartId);
        }
    }
}
