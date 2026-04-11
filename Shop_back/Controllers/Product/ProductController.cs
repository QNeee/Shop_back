using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.Product;
using Shop_back.Contracts.Response.Product;
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;

namespace Shop_back.Controllers.Product
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IValidator<CreateProductRequest> _createProductValidator;
        private readonly IValidator<UpdateProductImagesRequest> _updateImagesValidator;
        private readonly IValidator<UpdateProductMainInfoRequest> _updateMainInfoValidator;
        private readonly IValidator<UpdateProductVariantsRequest> _updateVariantsValidator;
        public ProductController(IProductService service, IValidator<CreateProductRequest> createProductValidator,
            IValidator<UpdateProductImagesRequest> updateImagesValidator,
                IValidator<UpdateProductMainInfoRequest> updateMainInfoValidator,
                IValidator<UpdateProductVariantsRequest> updateVariantsValidator)
        {
            _service = service;
            _createProductValidator = createProductValidator;
            _updateImagesValidator = updateImagesValidator;
            _updateMainInfoValidator = updateMainInfoValidator;
            _updateVariantsValidator = updateVariantsValidator;
        }
        private static async Task<List<string>> ValidateRequest<T>(IValidator<T> validator, T request)
        {
            var validationResult = await validator.ValidateAsync(request);
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        [HttpGet]
        public async Task<ActionResult<GetAllProductsResponse>> GetAllProducts()
        {

            var res = await _service.GetAllProducts();
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductRequest req)
        {
            var errors = await ValidateRequest(_createProductValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var product = new ProductModel(req.Title, req.Description, req.Images, req.Variants, req.Type);
            var productId = await _service.CreateProduct(product);
            return Ok(productId);
        }
        [HttpPut("images/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartImages(Guid id, [FromBody] UpdateProductImagesRequest req)
        {
            await ValidateRequest(_updateImagesValidator, req);
            var smartId = await _service.UpdateSmartImages(id, req.Images);
            return Ok(smartId);
        }
        [HttpPut("maininfo/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartMainInfo(Guid id, [FromBody] UpdateProductMainInfoRequest req)
        {
            var errors = await ValidateRequest(_updateMainInfoValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.UpdateSmartMainInfo(id, req.Title, req.Description);
            return Ok(smartId);
        }
        [HttpPut("variants/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSmartVariants(Guid id, [FromBody] UpdateProductVariantsRequest req)
        {

            var errors = await ValidateRequest(_updateVariantsValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.UpdateSmartVariants(id, req.Variants);
            return Ok(smartId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSmart(Guid id)
        {
            var product = await _service.GetProductById(id);
            if (product == null) return NotFound($"product with id {id} not found");
            var smartId = await _service.DeleteProduct(id);
            return Ok(smartId);
        }
    }
}
