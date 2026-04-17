using FluentValidation;
using Shop_back.Contracts.Request.Product;

namespace Shop_back.Validation.Product
{
    public class UpdateProductMainInfoRequestValidator : AbstractValidator<UpdateProductMainInfoRequest>
    {
        private readonly int Min_Length_STR = 2;
        private readonly int Max_Length_STR = 500;

        public UpdateProductMainInfoRequestValidator()
        {
            RuleFor(x => x.ProductName)
           .NotEmpty()
           .MinimumLength(Min_Length_STR)
           .MaximumLength(Max_Length_STR);

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull();
        }
    }
    public class UpdateProductVariantsRequestValidator : AbstractValidator<UpdateProductVariantsRequest>
    {
        public UpdateProductVariantsRequestValidator()
        {
            RuleFor(x => x.Variants).NotNull().NotEmpty();
            RuleForEach(x => x.Variants).ChildRules(variant =>
            {
                variant.RuleFor(x => x.MemoryGb).NotEmpty().NotNull().GreaterThan(0);
                variant.RuleFor(x => x.StorageGb).NotEmpty().NotNull().GreaterThan(0);
                variant.RuleFor(x => x.Stock).GreaterThan(0);
                variant.RuleFor(x => x.Price).GreaterThan(0);
            });

        }
    }
    public class UpdateProductOptionsRequestValidator : AbstractValidator<UpdateProductOptionsRequest>
    {
        public UpdateProductOptionsRequestValidator()
        {
            RuleFor(x => x.Options)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Options.Cores).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Options.PowerW).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Options.ScreenSize).NotEmpty().NotNull();
            RuleFor(x => x.Options.ScreenResolution).NotEmpty().NotNull();
        }
    }
    public class UpdateProductImagesRequestValidator : AbstractValidator<UpdateProductImagesRequest>
    {
        public UpdateProductImagesRequestValidator()
        {
            RuleFor(x => x.Images)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Images)
                .Must(x => !string.IsNullOrWhiteSpace(x.Key))
                .WithMessage("Image key cannot be empty.");

            RuleForEach(x => x.Images)
                .Must(x => x.Value != null && x.Value.Length > 0)
                .WithMessage("Image value must contain at least one image.");

            RuleForEach(x => x.Images)
                .Must(x => x.Value.All(url => !string.IsNullOrWhiteSpace(url)))
                .WithMessage("Image URLs cannot contain empty values.");
        }
    }
    public class UpdateProductVariantRequestValidator : AbstractValidator<UpdateProductVariantRequest>
    {
        public UpdateProductVariantRequestValidator()
        {
            RuleFor(x=> x.ProductVariantId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Variant)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Variant.MemoryGb).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Variant.StorageGb).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Variant.Stock).GreaterThan(0);
            RuleFor(x => x.Variant.Price).GreaterThan(0);
        }
    }

}
