using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatorPattern.Domain;
using MediatorPattern.Persistence;
using MediatR;

namespace MediatorPattern.Application.Elements
{
    public class CreateElement : IRequest<int>
    {
        public Element Element { get; set; }
    }

    public class CreateElementHandler : IRequestHandler<CreateElement, int>
    {
        private readonly ElementsContext _context;
        private readonly IValidator<CreateElement> _validator;

        public CreateElementHandler(ElementsContext context, IValidator<CreateElement> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<int> Handle(CreateElement request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, strategy => strategy.ThrowOnFailures(), cancellationToken);
            request.Element.Id = 0;
            var entry = await _context.Elements.AddAsync(request.Element, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entry.Entity.Id;
        }
    }
}