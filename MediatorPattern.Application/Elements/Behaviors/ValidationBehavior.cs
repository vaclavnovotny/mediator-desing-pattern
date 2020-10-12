using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace MediatorPattern.Application.Elements.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidationBehavior(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validator = _validatorFactory.GetValidator<TRequest>();
            if (validator != null)
                await validator.ValidateAsync(request, strategy => strategy.ThrowOnFailures(), cancellationToken);

            return await next();
        }
    }
}