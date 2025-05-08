using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetStrategist.ApiExample.FakeStrategies;

namespace NetStrategist.ApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IStrategistFor<IShippingService, string> _shippingStrategist;

        public ShippingController(IStrategistFor<IShippingService, string> shippingStrategist)
        {
            _shippingStrategist = shippingStrategist;
        }


        [HttpGet("{shippingMethod}")]
        public IActionResult Ship(string shippingMethod)
        {
            if (!_shippingStrategist.TryGetStrategy(shippingMethod, out var shippingService))
            {
                return NotFound($"Shipping method '{shippingMethod}' not found.");
            }
            var result = shippingService.Ship();
            return Ok(result);
        }

    }
}
