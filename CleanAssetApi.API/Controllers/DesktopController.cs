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
        private readonly ILoggerManager _logger;
        private readonly IDesktopService _desktopService;
        private readonly IFakeDesktopService _fakeDesktopService;
        private readonly IWebHostEnvironment _dev;
        public DesktopController(
            IDesktopService desktopService,
             ILoggerManager loggerManager,
             IFakeDesktopService fakeDesktopService,
             IWebHostEnvironment dev)
        {
            _logger = loggerManager;
            _desktopService = desktopService;
            _fakeDesktopService = fakeDesktopService;
            _dev = dev;

        }
        // GET: api/<DesktopController>
        [HttpGet]
        public async Task<IActionResult> GetDesktops([FromQuery] DesktopQueryStringParameters desktopQueryStringParameters)
        {
            PagedList<Desktop> _desktops;
            if (_dev.IsDevelopment())
            {
                _desktops = await _fakeDesktopService.fakeGetDesktops(desktopQueryStringParameters);
            }
            else
            {
                _desktops = await _desktopService.GetDesktops(desktopQueryStringParameters);
            }


            var metadata = new
            {
                _desktops.TotalCount,
                _desktops.PageSize,
                _desktops.CurrentPage,
                _desktops.TotalPages,
                _desktops.HasNext,
                _desktops.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(_desktops);

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
            if (_dev.IsDevelopment())
            {
                _fakeDesktopService.fakeCreateDesktop(desktop);
            }
            else
            {
                _desktopService.CreateDesktop(desktop);
            }

        }

        // PUT api/<DesktopController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Desktop desktop)
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

                if (_dev.IsDevelopment())
                {
                    var desk = await _fakeDesktopService.fakeGetDesktopById(id);
                    if (desk == null)
                    {
                        throw new AssetDoesNotExistException(id.ToString());
                    }else
                    {
                         _fakeDesktopService.fakeDeleteDesktop(desk);
                    }
                   
                }
                else
                {
                    var desk = await _desktopService.GetDesktopById(id);
                    if (desk == null)
                    {
                        throw new AssetDoesNotExistException(id.ToString());
                    }else
                    {
                        _desktopService.DeleteDesktop(desk);
                    }
                    
                }

        }
    }
}
