using FluentValidation;

namespace MediatorPattern.Application.Elements.Validators
{
    public class CreateElementValidator : AbstractValidator<CreateElement>
    {
        public CreateElementValidator()
        {
            RuleFor(x => x.Element).Cascade(CascadeMode.Stop).NotNull()
                .ChildRules(rules =>
                {
                    rules.RuleFor(r => r.ImageId).GreaterThan(0);
                    rules.RuleFor(x => x.Name).NotEmpty();
                    rules.RuleFor(x => x.Size).NotNull().ChildRules(sRules =>
                    {
                        sRules.RuleFor(r => r.Height).GreaterThan(0);
                        sRules.RuleFor(r => r.Width).GreaterThan(0);
                    });
                    rules.RuleFor(x => x.Position).NotNull();
                });
        }
    }

    // live: do validator for delete element request with existence check
}