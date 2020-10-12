using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPattern.Application.Elements;
using MediatorPattern.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MediatorPattern.Controllers
{
    [ApiController, Route("elements")]
    public class ElementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all elements from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Element>))]
        public async Task<IActionResult> GetElements()
        {
            var elements = await _mediator.Send(new GetElements());
            return Ok(elements);
        }

        /// <summary>
        /// Get element by specified Id, returns null if not found.
        /// </summary>
        /// <param name="elementId"></param>
        /// <returns></returns>
        [HttpGet("{elementId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Element))]
        public async Task<IActionResult> GetElement([FromRoute, BindRequired] int elementId)
        {
            var element = await _mediator.Send(new GetElementById(){ElementId = elementId});
            return Ok(element);
        }

        /// <summary>
        /// Creates new element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> CreateElement([FromQuery, BindRequired] Element element)
        {
            var id = await _mediator.Send(new CreateElement(){Element = element});
            return Ok(id);
        }

        /// <summary>
        /// Deletes element with specified Id.
        /// </summary>
        /// <param name="elementId">Id of element to delete.</param>
        /// <returns></returns>
        [HttpDelete("{elementId}")]
        public async Task<IActionResult> DeleteElement([FromRoute, BindRequired] int elementId)
        {
            await _mediator.Send(new DeleteElement() {ElementId = elementId});
            return Ok();
        }
    }
}
