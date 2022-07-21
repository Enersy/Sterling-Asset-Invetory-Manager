using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure;

namespace CleanAssetApi.Application.Interfaces
{
    public interface IFakeDesktopService
    {
        Task<PagedList<Desktop>> fakeGetDesktops(DesktopQueryStringParameters desktopQueryStringParameters);
       Task<Desktop> fakeGetDesktopById(Guid DesktopId);
        void fakeCreateDesktop(Desktop Desktop);
        void fakeDeleteDesktop(Desktop Desktop);
    }
}
