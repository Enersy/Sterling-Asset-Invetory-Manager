namespace CleanAssetApi.API.Models
{
    public class RootResponse : Resource
    {
        public RootResponse()
        {
            
        }
        public Link Desktops { get; set; }

        public Link Laptops { get; set; }
    }
}