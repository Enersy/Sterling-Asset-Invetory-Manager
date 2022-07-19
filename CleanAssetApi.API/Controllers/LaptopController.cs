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
    public class LaptopController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ILaptopService _LaptopService;
        public LaptopController(
            ILaptopService LaptopService,
            ILoggerManager loggerManager
            )
        {
            _logger = loggerManager;
            _LaptopService = LaptopService;
         

        }
        // GET: api/<LaptopController>
        [HttpGet]
        public async Task<IActionResult> GetLaptops([FromBody] LaptopQueryStringParameters laptopQueryStringParameters)
        {
            _logger.LogInfo("Fetching all Laptops from the database");
            var Laptops = await _LaptopService.GetLaptops(laptopQueryStringParameters);
            _logger.LogInfo("Fetching all Laptops from the database Successfully");

            var metadata = new
            {
                Laptops.TotalCount,
                Laptops.PageSize,
                Laptops.CurrentPage,
                Laptops.TotalPages,
                Laptops.HasNext,
                Laptops.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(Laptops);

        }

        // GET api/<LaptopController>/5
        [HttpGet("{id}")]
        public async Task<Laptop> Get(Guid id)
        {
           
            var lap =await _LaptopService.GetLaptopById(id);
            if(lap == null) 
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
            return lap;
        }

        // POST api/<LaptopController>
        [HttpPost]
        public void Post([FromBody] Laptop Laptop)
        {
            _LaptopService.CreateLaptop(Laptop);
        }

        // PUT api/<LaptopController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Laptop Laptop)
        {
            var desk = await _LaptopService.GetLaptopById(id);
            if (desk != null)
            {
                _LaptopService.UpdateLaptopDetails(Laptop);
            }
            else 
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
        }

        // DELETE api/<LaptopController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var desk = await _LaptopService.GetLaptopById(id);
            if (desk != null)
            {
                _LaptopService.DeleteLaptop(desk);
            }
            else
            {
                throw new AssetDoesNotExistException(id.ToString());
            }
        }
    }
}
