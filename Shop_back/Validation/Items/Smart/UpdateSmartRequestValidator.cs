using FluentValidation;
using Shop_back.Contracts.Request.items.Smart;

namespace Shop_back.Validation.Items.Smart
{
    public class UpdateSmartMainInfoRequestValidator : AbstractValidator<UpdateSmartMainInfoRequest>
    {
        private readonly int Min_Length_STR = 5;
        private readonly int Max_Length_STR = 500;
      
        public UpdateSmartMainInfoRequestValidator()
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
    public class UpdateSmartVariantsRequestValidator : AbstractValidator<UpdateSmartVariantsRequest>
    {
        private readonly int Max_Discount = 100;
        public UpdateSmartVariantsRequestValidator()
        {
            RuleFor(x => x.Variants).NotNull().NotEmpty();
            RuleForEach(x => x.Variants).ChildRules(variant =>
            {
                variant.RuleFor(x => x.Id).NotNull().NotEmpty();
                variant.RuleFor(x => x.SmartId).NotNull().NotEmpty();
                variant.RuleFor(x => x.Options).NotNull().NotEmpty();
                variant.RuleFor(x => x.Options.Memory).NotEmpty().NotNull();
                variant.RuleFor(x => x.Options.Storage).NotEmpty().NotNull();
                variant.RuleFor(x => x.Options.Stock).GreaterThan(0);
                variant.RuleFor(x => x.Options.Price).GreaterThan(0);
                variant.RuleFor(x => x.Options.Discount)
            .Must(d =>
            d == null ||
         (d.Percent >= 0 && d.Percent <= Max_Discount && d.ExpiresAt > DateTime.Now)
     )
     .WithMessage($"Discount percent must be between 0 and {Max_Discount} and expiration must be in the future");
            });

        }
    }
    public class UpdateSmartImagesRequestValidator : AbstractValidator<UpdateSmartImagesRequest>
    {
        public UpdateSmartImagesRequestValidator()
        {
            RuleFor(x => x.SmartImages)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.SmartImages)
                .Must(x => !string.IsNullOrWhiteSpace(x.Key))
                .WithMessage("Image key cannot be empty.");

            RuleForEach(x => x.SmartImages)
                .Must(x => x.Value != null && x.Value.Length > 0)
                .WithMessage("Image value must contain at least one image.");

            RuleForEach(x => x.SmartImages)
                .Must(x => x.Value.All(url => !string.IsNullOrWhiteSpace(url)))
                .WithMessage("Image URLs cannot contain empty values.");
        }
    }

}
