using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Domain;
using CleanAssetApi.Domain.Exceptions;
using CleanAssetApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanAssetApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesktopController : ControllerBase
    {
        private readonly ILoggerManager  _logger;
        private readonly IDesktopService _desktopService;
        public DesktopController(IDesktopService desktopService, ILoggerManager loggerManager)
        {
            _logger= loggerManager;
            _desktopService = desktopService; 

        }
        // GET: api/<DesktopController>
        [HttpGet]
        public async Task<IActionResult> GetDesktops([FromQuery] DesktopQueryStringParameters desktopQueryStringParameters)
        {
            var desktops = await _desktopService.GetDesktops(desktopQueryStringParameters);

            var metadata = new
            {
               desktops.TotalCount,
               desktops.PageSize,
               desktops.CurrentPage,
               desktops.TotalPages,
               desktops.HasNext,
               desktops.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(desktops);
            
        }

        // GET api/<DesktopController>/5
        [HttpGet("{id}")]
        public async Task<Desktop> Get(Guid id)
        {
            var desk = await _desktopService.GetDesktopById(id);
            if (desk == null)
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
            return desk;
        }

        // POST api/<DesktopController>
        [HttpPost]
        public void Post([FromBody] Desktop desktop)
        {
            _desktopService.CreateDesktop(desktop);
        }

        // PUT api/<DesktopController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Desktop  desktop)
        {
            var desk = await _desktopService.GetDesktopById(id);
            if (desk == null)
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
            else
            {
                _desktopService.UpdateDesktopDetails(desktop);
            }
        }

        // DELETE api/<DesktopController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var desk = await _desktopService.GetDesktopById(id);
            if (desk == null)
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
            else
            {
                _desktopService.DeleteDesktop(desk);
            }

        }
    }
}
