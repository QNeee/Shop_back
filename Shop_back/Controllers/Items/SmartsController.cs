using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.items.Smart;
using Shop_back.Contracts.Response.Items;
using Shop_back.Core.Abstractions.Items.Smarts;

namespace Shop_back.Controllers.Items
{
    [ApiController]
    [Route("api/items/smarts")]
    public class SmartsController : ControllerBase
    {
        private readonly ISmartsService _service;
        private readonly IValidator<CreateSmartRequest> _createValidator;
        private readonly IValidator<UpdateSmartImagesRequest> _updateImagesValidator;
        private readonly IValidator<UpdateSmartMainInfoRequest> _updateMainInfoValidator;
        private readonly IValidator<UpdateSmartVariantsRequest> _updateVariantsValidator;
        private async Task<List<string>> ValidateRequest<T>(IValidator<T> validator, T request)
        {
            var validationResult = await validator.ValidateAsync(request);
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        public SmartsController(
            ISmartsService service,
            IValidator<CreateSmartRequest> createSmartRequestValidator,
            IValidator<UpdateSmartImagesRequest> updateImagesValidator,
            IValidator<UpdateSmartMainInfoRequest> updateFieldsValidator,
            IValidator<UpdateSmartVariantsRequest> updateVariantsValidator
            )
        {
            _service = service;
            _createValidator = createSmartRequestValidator;
            _updateImagesValidator = updateImagesValidator;
            _updateMainInfoValidator = updateFieldsValidator;
            _updateVariantsValidator = updateVariantsValidator;
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

            var errors = await ValidateRequest(_createValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.CreateSmart(req.Title, req.Description, req.Options, req.SmartImages);

            return Ok(smartId);
        }
        [HttpPut("images/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartImages(Guid id, [FromBody] UpdateSmartImagesRequest req)
        {
            await ValidateRequest(_updateImagesValidator, req);
            var smartId = await _service.UpdateSmartImages(id, req.SmartImages);
            return Ok(smartId);
        }
        [HttpPut("maininfo/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartMainInfo(Guid id, [FromBody] UpdateSmartMainInfoRequest req)
        {
            var errors = await ValidateRequest(_updateMainInfoValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.UpdateSmartMainInfo(id, req.Title, req.Description);
            return Ok(smartId);
        }
        [HttpPut("variants/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartVariants(Guid id, [FromBody] UpdateSmartVariantsRequest req)
        {

            var errors = await ValidateRequest(_updateVariantsValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.UpdateSmartVariants(id, req.Variants);
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
