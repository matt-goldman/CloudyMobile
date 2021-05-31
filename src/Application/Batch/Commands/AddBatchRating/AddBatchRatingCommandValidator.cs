using FluentValidation;

namespace CloudyMobile.Application.Batch.Commands.AddBatchRating
{
    public class AddBatchRatingCommandValidator : AbstractValidator<AddBatchRatingCommand>
    {
        public AddBatchRatingCommandValidator()
        {
            RuleFor(v => v.Rating)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5);
        }
    }
}
