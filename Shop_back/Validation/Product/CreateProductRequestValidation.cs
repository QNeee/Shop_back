using FluentValidation;
using Shop_back.Contracts.Request.Product;  
namespace Shop_back.Validation.Product
{
    public class CreateProductRequestValidation : AbstractValidator<CreateProductRequest>
    {
        private readonly int Min_Length_STR = 2;
        private readonly int Max_Length_STR = 500;
        public CreateProductRequestValidation()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MinimumLength(Min_Length_STR)
                .MaximumLength(Max_Length_STR);

            RuleFor(x => x.CategoryId)
                .NotEmpty().NotNull();

            RuleForEach(x => x.Variants).ChildRules(variant =>
            {
                variant.RuleFor(x => x.MemoryGb).NotEmpty().GreaterThan(0);
                variant.RuleFor(x => x.StorageGb).NotEmpty().GreaterThan(0);
                variant.RuleFor(x => x.Stock).GreaterThan(0);
                variant.RuleFor(x => x.Price).GreaterThan(0);
            });

            RuleFor(x => x.Options.PowerW).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Options.Cores).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Options.ScreenSize).NotEmpty().NotNull();
            RuleFor(x => x.Options.ScreenResolution).NotEmpty().NotNull();


            RuleFor(x => x.Images)
    .NotNull()
    .WithMessage("Images is required")
    .Must(images => images.Count != 0)
    .WithMessage("At least one image group is required");
        }
    }
}
