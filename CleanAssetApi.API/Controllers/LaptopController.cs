using CleanAssetApi.API.Models;
using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Domain;
using CleanAssetApi.Domain.Exceptions;
using CleanAssetApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly PagingOptions _defaultPagingOptions;
        public LaptopController(
            ILaptopService LaptopService,
            ILoggerManager loggerManager,
            IOptions<PagingOptions> defaultPagingOptionsWrapper)
        {
            _logger = loggerManager;
            _LaptopService = LaptopService;
         _defaultPagingOptions = defaultPagingOptionsWrapper.Value;

        }
        // GET: api/<LaptopController>
        [HttpGet(Name = nameof(GetLaptops))]
        public async Task<IActionResult> GetLaptops(
           [FromBody] LaptopQueryStringParameters laptopQueryStringParameters)
        {
            _logger.LogInfo("Fetching all Laptops from the database");
            var Laptops = await _LaptopService.GetLaptops(laptopQueryStringParameters);
            _logger.LogInfo("Fetching all Laptops from the database Successfully");


           // pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
           // pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            
            var collection = PagedCollection<Laptop>.Create<LaptopResponse>(
                Link.ToCollection(nameof(GetLaptops)),
                Laptops.ToArray(),
                Laptops.PageSize,
                _defaultPagingOptions);

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

            return Ok(collection);

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
