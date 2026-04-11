using FluentValidation;
using Shop_back.Contracts.Request.Product;

namespace Shop_back.Validation.Product
{
    public class UpdateProductMainInfoRequestValidator : AbstractValidator<UpdateProductMainInfoRequest>
    {
        private readonly int Min_Length_STR = 5;
        private readonly int Max_Length_STR = 500;

        public UpdateProductMainInfoRequestValidator()
        {
            RuleFor(x => x.Title)
           .NotEmpty()
           .MinimumLength(Min_Length_STR)
           .MaximumLength(Max_Length_STR);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(Min_Length_STR)
                .MaximumLength(Max_Length_STR);
        }
    }
    public class UpdateProductVariantsRequestValidator : AbstractValidator<UpdateProductVariantsRequest>
    {
        public UpdateProductVariantsRequestValidator()
        {
            RuleFor(x => x.Variants).NotNull().NotEmpty();
            RuleForEach(x => x.Variants).ChildRules(variant =>
            {
                variant.RuleFor(x => x.Id).NotNull().NotEmpty();
                variant.RuleFor(x => x.ProductId).NotNull().NotEmpty();
                variant.RuleFor(x => x.Memory).NotEmpty().NotNull();
                variant.RuleFor(x => x.Storage).NotEmpty().NotNull();
                variant.RuleFor(x => x.Stock).GreaterThan(0);
                variant.RuleFor(x => x.Price).GreaterThan(0);
            });

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

}
