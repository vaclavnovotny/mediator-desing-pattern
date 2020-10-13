using FluentValidation;
using MediatorPattern.Domain;

namespace MediatorPattern.Application.Elements.Validators
{
    public class ElementValidator : AbstractValidator<Element>
    {
        public ElementValidator()
        {
            RuleFor(r => r.ImageId).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Size).Cascade(CascadeMode.Stop).NotNull().ChildRules(sRules =>
            {
                sRules.RuleFor(r => r.Height).GreaterThan(0);
                sRules.RuleFor(r => r.Width).GreaterThan(0);
            });
            RuleFor(x => x.Position).NotNull();
        }
    }
}