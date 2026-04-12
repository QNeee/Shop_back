using FluentValidation;
using Shop_back.Contracts.Request.Shares;


namespace Shop_back.Validation.Shares
{
    public class CreateShareRequestValdation : AbstractValidator<CreateShareRequset>
    {
        public CreateShareRequestValdation()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull();
            RuleFor(x=>x.VariantId).NotEmpty().NotNull();
            RuleFor(x=>x.Discount.Percentage).ExclusiveBetween(0, 100);
        }
    }
}
