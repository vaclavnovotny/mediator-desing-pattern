using System.Threading;
using System.Threading.Tasks;
using MediatorPattern.Domain;
using MediatorPattern.Persistence;
using MediatR;

namespace MediatorPattern.Application.Elements
{
    public class GetElementById : IRequest<Element>
    {
        public int ElementId { get; set; }
    }

    public class GetElementByIdHandler : IRequestHandler<GetElementById, Element>
    {
        private readonly ElementsContext _context;

        public GetElementByIdHandler(ElementsContext context)
        {
            _context = context;
        }

        public async Task<Element> Handle(GetElementById request, CancellationToken cancellationToken)
        {
            return await _context.Elements.FindAsync(request.ElementId);
        }
    }
}