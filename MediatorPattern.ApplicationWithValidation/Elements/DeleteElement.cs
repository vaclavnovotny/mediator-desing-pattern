using System.Threading;
using System.Threading.Tasks;
using MediatorPattern.Persistence;
using MediatR;

namespace MediatorPattern.Application.Elements
{
    public class DeleteElement : IRequest
    {
        public int ElementId { get; set; }
    }

    public class DeleteElementHandler : AsyncRequestHandler<DeleteElement>
    {
        private readonly ElementsContext _context;

        public DeleteElementHandler(ElementsContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteElement request, CancellationToken cancellationToken)
        {
            _context.Elements.Remove(await _context.Elements.FindAsync(request.ElementId));
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}