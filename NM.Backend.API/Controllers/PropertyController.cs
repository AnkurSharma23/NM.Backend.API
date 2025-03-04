using Microsoft.AspNetCore.Mvc;
using NM.Backend.API.Resource;

namespace NM.Backend.API.Controllers
{
    [ApiController]
    [Tags("Property")]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyResource _propertyResource;

        public PropertyController(IPropertyResource propertyResource)
        {
            _propertyResource = propertyResource;
        }

        //TODO : Implement proper filtering and pagination for the LIST call

        /// <summary>
        /// Allows an API consumer to get the list of all the properties
        /// </summary>
        /// <returns>Collection of properties</returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] int top = 100,
            [FromQuery] int skip = 0, [FromQuery] string filter = null,
            [FromQuery] string orderBy = null)
        {
            // TODO: Get the details using chunking and filtering and return the response

            var properties = await _propertyResource.GetPropertyDataFromBlobStorageAsync();
            if (properties == null)
            {
                return NotFound();
            }
            return Ok(properties);
        }
    }
}
