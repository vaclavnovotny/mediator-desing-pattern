using FluentValidation;
using MediatorPattern.Domain;

namespace MediatorPattern.Application.Elements.Validators
{
    public class CreateElementValidator : AbstractValidator<CreateElement>
    {
        public CreateElementValidator(IValidator<Element> validator)
        {
            RuleFor(x => x.Element)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .SetValidator(validator);
        }
    }
}