using FluentValidation;
using Shop_back.Contracts.Request.items.Smart;

public class CreateSmartRequestValidator : AbstractValidator<CreateSmartRequest>
{
    private readonly int Min_Length_STR = 5;
    private readonly int Max_Length_STR = 500;
    private readonly int Max_Discount = 100;
    public CreateSmartRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(Min_Length_STR)
            .MaximumLength(Max_Length_STR);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(Min_Length_STR)
            .MaximumLength(Max_Length_STR);

        RuleFor(x => x.Options)
            .NotNull()
            .NotEmpty();

        RuleForEach(x => x.Options).ChildRules(option =>
        {
            option.RuleFor(x => x.Memory).NotEmpty();
            option.RuleFor(x => x.Storage).NotEmpty();
            option.RuleFor(x => x.Stock).GreaterThan(0);
            option.RuleFor(x => x.Price).GreaterThan(0);
            option.RuleFor(x => x.Discount)
            .Must(d =>
            d == null ||
         (d.Percent >= 0 && d.Percent <= Max_Discount && d.ExpiresAt > DateTime.Now)
     )
     .WithMessage($"Discount percent must be between 0 and {Max_Discount} and expiration must be in the future");
        });
    }
}