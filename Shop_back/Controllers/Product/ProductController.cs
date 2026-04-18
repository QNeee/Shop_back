using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop_back.Contracts.Request.Product;
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductCatalog;
using Shop_back.Core.Models.Product.ProductShares;

namespace Shop_back.Controllers.Product
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IValidator<CreateProductRequest> _createProductValidator;
        private readonly IValidator<UpdateProductImagesRequest> _updateImagesValidator;
        private readonly IValidator<UpdateProductMainInfoRequest> _updateMainInfoValidator;
        private readonly IValidator<UpdateProductVariantsRequest> _updateVariantsValidator;
        private readonly IValidator<UpdateProductVariantRequest> _updateVariantValidator;

        private readonly IValidator<UpdateProductOptionsRequest> _updateOptionsValidator;
        public ProductController(IProductService service, IValidator<CreateProductRequest> createProductValidator,
            IValidator<UpdateProductImagesRequest> updateImagesValidator,
                IValidator<UpdateProductMainInfoRequest> updateMainInfoValidator,
                IValidator<UpdateProductVariantsRequest> updateVariantsValidator,
                IValidator<UpdateProductOptionsRequest> updateOptionsValidator,
                IValidator<UpdateProductVariantRequest> updateVariantValidator
                )
        {
            _service = service;
            _createProductValidator = createProductValidator;
            _updateImagesValidator = updateImagesValidator;
            _updateMainInfoValidator = updateMainInfoValidator;
            _updateVariantsValidator = updateVariantsValidator;
            _updateOptionsValidator = updateOptionsValidator;
            _updateVariantValidator = updateVariantValidator;
        }
        private static async Task<List<string>> ValidateRequest<T>(IValidator<T> validator, T request)
        {
            var validationResult = await validator.ValidateAsync(request);
            return validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductCatalogModel>>> GetAllProducts([FromQuery] int? categoryId = null)
        {
            return Ok(await _service.GetAllCatalogProducts(categoryId));
        }
        [HttpGet("shares")]
        public async Task<ActionResult<List<ProductCatalogModel>>> GetAllSharesProducts([FromQuery] int? categoryId = null)
        {
            return Ok(await _service.GetAllSharesProducts(categoryId));
        }
        [HttpGet("basket")]
        public async Task<ActionResult<List<ProductSharesModel>>> GetAllBasketProducts([FromQuery] List<Guid> ids)
        {
            return Ok(await _service.GetAllBasketProducts(ids));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductRequest req)
        {
            var errors = await ValidateRequest(_createProductValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var product = new ProductModel { CategoryId = req.CategoryId, ProductName = req.ProductName, Options = req.Options, Images = req.Images, Variants = req.Variants };
            var productId = await _service.CreateProduct(product);
            return Ok(productId);
        }
        [HttpPut("images/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProductImages(Guid id, [FromBody] UpdateProductImagesRequest req)
        {
            await ValidateRequest(_updateImagesValidator, req);
            var smartId = await _service.UpdateProductImages(id, req.Images);
            return Ok(smartId);
        }
        [HttpPut("options/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProductOptions(Guid id, [FromBody] UpdateProductOptionsRequest req)
        {
            await ValidateRequest(_updateOptionsValidator, req);
            var smartId = await _service.UpdateProductOptions(id, req.Options);
            return Ok(smartId);
        }
        [HttpPut("maininfo/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProductMainInfo(Guid id, [FromBody] UpdateProductMainInfoRequest req)
        {
            var errors = await ValidateRequest(_updateMainInfoValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var isCategoryExists = await _service.GetCategoryExists(req.CategoryId);
            if (!isCategoryExists)
            {
                return BadRequest(new { Errors = new List<string> { $"Category with ID {req.CategoryId} does not exist." } });
            }
            var smartId = await _service.UpdateProductMainInfo(id, req.ProductName, req.CategoryId);
            return Ok(smartId);
        }
        [HttpPut("variants/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProductVariants(Guid id, [FromBody] UpdateProductVariantsRequest req)
        {

            var errors = await ValidateRequest(_updateVariantsValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            var smartId = await _service.UpdateProductVariants(id, req.Variants);
            return Ok(smartId);
        }
        [HttpPut("variant/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateProductVariant(Guid id, [FromBody] UpdateProductVariantRequest req)
        {
            var errors = await ValidateRequest(_updateVariantValidator, req);
            if (errors.Count > 0) return BadRequest(new { Errors = errors });
            Console.WriteLine(req.Variant.ProductVariantId);
            var isProductExists = await _service.GetProductVariantExists(id, req.ProductVariantId);
            if (!isProductExists)   
            {
                return BadRequest(new { Errors = new List<string> { $"Product variant with ID {req.Variant.ProductVariantId} does not exist." } });
            }
            var smartId = await _service.UpdateProductVariant(id, req.Variant, req.ProductVariantId);
            return Ok(smartId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid id)
        {
            var smartId = await _service.DeleteProduct(id);
            return Ok(smartId);
        }
    }
}
