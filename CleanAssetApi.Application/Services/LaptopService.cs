using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure;
using CleanAssetApi.Infrastructure.DBInterfaces;


namespace CleanAssetApi.Application.Services
{
    public class LaptopService:ILaptopService
    {
        private readonly ILaptopRepository _repository;
        public LaptopService(ILaptopRepository LaptopRespository)
        {
            _repository = LaptopRespository;
        }
        public Task<PagedList<Laptop>> GetLaptops(LaptopQueryStringParameters laptopQueryStringParameter) 
        {
          return  _repository.GetAll(laptopQueryStringParameter);
        }
        public Task<Laptop> GetLaptopById(Guid LaptopId)
        {
            return _repository.GetLaptopById(LaptopId);
        }
        public void UpdateLaptopDetails(Laptop  laptop)
        {
            _repository.UpdateLaptop(laptop);
        }
        public void CreateLaptop(Laptop laptop)
        {
            _repository.CreateLaptop(laptop);
        }
        public void DeleteLaptop(Laptop laptop)
        {
            _repository.DeleteLaptop(laptop);
        }
    }
}
