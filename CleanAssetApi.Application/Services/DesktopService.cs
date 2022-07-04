using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Infrastructure.Repositories;
using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure.DBInterfaces;
using CleanAssetApi.Infrastructure;

namespace CleanAssetApi.Application.Services
{
    public class DesktopService:IDesktopService
    {
        private readonly IDesktopRepository _repository;
        public DesktopService(IDesktopRepository DesktopRespository)
        {
            _repository = DesktopRespository;
        }
        public Task<PagedList<Desktop>> GetDesktops(DesktopQueryStringParameters desktopQueryStringParameters)
        {
            return  _repository.GetAll(desktopQueryStringParameters);
        }
        public Task<Desktop> GetDesktopById(Guid DesktopId)
        {
            return _repository.GetDesktopById(DesktopId);
        }
        public void UpdateDesktopDetails(Desktop Desktop)
        {
            _repository.UpdateDesktop(Desktop);
        }
        public void CreateDesktop(Desktop Desktop)
        {
            _repository.CreateDesktop(Desktop);
        }
        public void DeleteDesktop(Desktop Desktop)
        {
            _repository.DeleteDesktop(Desktop);
        }
    }
}
