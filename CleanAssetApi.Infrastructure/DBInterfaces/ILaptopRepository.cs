using CleanAssetApi.Domain;

namespace CleanAssetApi.Infrastructure.DBInterfaces
{
    public interface ILaptopRepository:IBaseRepository<Laptop>
    {
        Task<PagedList<Laptop>> GetAll(LaptopQueryStringParameters laptopQueryStringParameter);
        Task<Laptop> GetLaptopById(Guid LaptopId);
        void CreateLaptop(Laptop Laptop);
        void UpdateLaptop(Laptop Laptop);
        void DeleteLaptop(Laptop Laptop);

    }
}
