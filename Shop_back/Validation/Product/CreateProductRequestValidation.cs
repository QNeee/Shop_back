using FluentValidation;
using Shop_back.Contracts.Request.Product;  
namespace Shop_back.Validation.Product
{
    public class CreateProductRequestValidation : AbstractValidator<CreateProductRequest>
    {
        private readonly int Min_Length_STR = 5;
        private readonly int Max_Length_STR = 500;
        public CreateProductRequestValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(Min_Length_STR)
                .MaximumLength(Max_Length_STR);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(Min_Length_STR)
                .MaximumLength(Max_Length_STR);

            RuleForEach(x => x.Variants).ChildRules(variant =>
            {
                variant.RuleFor(x => x.ProductId).NotEmpty().NotNull();
                variant.RuleFor(x => x.Memory).NotEmpty();
                variant.RuleFor(x => x.Storage).NotEmpty();
                variant.RuleFor(x => x.Stock).GreaterThan(0);
                variant.RuleFor(x => x.Price).GreaterThan(0);
            });
        }
    }
}
