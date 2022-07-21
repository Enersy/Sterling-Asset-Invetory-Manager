using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure;
using CleanAssetApi.Infrastructure.DBInterfaces;

namespace CleanAssetApi.Application.Services
{
    public class FakeDesktopService : IFakeDesktopService
    {
        private readonly IFakeDesktopRepository _fakerepository;
        public FakeDesktopService(IFakeDesktopRepository fakeDesktopRespository)
        {
            _fakerepository = fakeDesktopRespository;
        }

        public async void fakeCreateDesktop(Desktop Desktop)
        {
            _fakerepository.CreateDesktop(Desktop);
        }

        public async void fakeDeleteDesktop(Desktop Desktop)
        {
            _fakerepository.DeleteDesktop(Desktop);
        }

        public async Task<Desktop> fakeGetDesktopById(Guid DesktopId)
        {
           return await _fakerepository.GetDesktopById(DesktopId);
        }

        public async Task<PagedList<Desktop>> fakeGetDesktops(DesktopQueryStringParameters desktopQueryStringParameters)
        {
            return await _fakerepository.GetAll(desktopQueryStringParameters);
        }

       
    }
}
