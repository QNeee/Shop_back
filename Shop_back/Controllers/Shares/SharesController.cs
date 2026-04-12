using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.Product;
using Shop_back.Contracts.Request.Shares;
using Shop_back.Contracts.Response.Shares;
using Shop_back.Core.Abstractions.Shares;
using Shop_back.Core.Models.Shares;

namespace Shop_back.Controllers.Shares
{
    [ApiController]
    [Route("api/shares")]
    public class SharesController : ControllerBase
    {
        private readonly ISharesService _service;
        private readonly IValidator<CreateShareRequset> _createShareValidator;
        public SharesController(ISharesService service , IValidator<CreateShareRequset> createShareValidator)
        {
            _service = service;
            _createShareValidator = createShareValidator;
        }
        private static async Task<List<string>> ValidateRequest<T>(IValidator<T> validator, T request)
        {
            var validationResult = await validator.ValidateAsync(request);
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateShare([FromBody] CreateShareRequset req)
        {
            var errors = await ValidateRequest(_createShareValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            Console.WriteLine($"Received CreateShare request: Discount={req.Discount}, ProductId={req.ProductId}, VariantId={req.VariantId}");
            var share = new Share { Discount = req.Discount, ProductId = req.ProductId, VariantId = req.VariantId };
            var smartId = await _service.CreateShare(share);
            return Ok(smartId);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetSharesResponse>>> GetSharesSmarts()
        {
            var response = await _service.GetSharesProducts();
            return Ok(response);
        }
    }
}
