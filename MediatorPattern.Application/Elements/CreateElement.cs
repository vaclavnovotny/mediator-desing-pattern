using System.Threading;
using System.Threading.Tasks;
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

        public CreateElementHandler(ElementsContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateElement request, CancellationToken cancellationToken)
        {
            request.Element.Id = 0;
            var entry = await _context.Elements.AddAsync(request.Element, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entry.Entity.Id;
        }
    }
}