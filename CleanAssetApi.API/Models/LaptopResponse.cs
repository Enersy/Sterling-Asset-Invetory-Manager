using CleanAssetApi.Domain;

namespace CleanAssetApi.API.Models
{
    public class LaptopResponse : PagedCollection<Laptop>
    {
        public Link Laptops { get; set; }

        
    }
}
