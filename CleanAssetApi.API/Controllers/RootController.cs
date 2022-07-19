using CleanAssetApi.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace CleanAssetApi.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
         [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                Desktops = Link.ToCollection(nameof(DesktopController.GetDesktops)),
                Laptops = Link.To(nameof(LaptopController.GetLaptops))
            };

            return Ok(response);
        }
    }
}