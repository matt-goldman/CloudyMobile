using FluentValidation;

namespace CloudyMobile.Application.Kegs.Commands.AddKeg
{
    public class AddKegCommandValidator : AbstractValidator<AddKegCommand>
    {
        public AddKegCommandValidator()
        {
            RuleFor(v => v.BatchId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(v => v.LocationId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
