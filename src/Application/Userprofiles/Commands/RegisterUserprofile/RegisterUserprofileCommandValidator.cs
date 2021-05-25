using FluentValidation;

namespace CloudyMobile.Application.Userprofiles.Commands.RegisterUserprofile
{
    public class CreateTodoItemCommandValidator : AbstractValidator<RegisterUserprofileCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Firstname)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.HomeAddress)
                .NotEmpty();

            RuleFor(v => v.WorkAddress)
                .NotEmpty();
        }
    }
}