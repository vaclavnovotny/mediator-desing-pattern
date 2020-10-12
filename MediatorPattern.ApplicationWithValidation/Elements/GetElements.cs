using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatorPattern.Domain;
using MediatorPattern.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Application.Elements
{
    public class GetElements : IRequest<IEnumerable<Element>>
    {
        // Filter, Features, etc...
    }

    public class GetElementsHandler : IRequestHandler<GetElements, IEnumerable<Element>>
    {
        private readonly ElementsContext _elementsContext;

        public GetElementsHandler(ElementsContext elementsContext)
        {
            _elementsContext = elementsContext;
        }

        public async Task<IEnumerable<Element>> Handle(GetElements request, CancellationToken cancellationToken)
        {
            var elements = await _elementsContext
                .Elements
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return elements;
        }
    }
}
