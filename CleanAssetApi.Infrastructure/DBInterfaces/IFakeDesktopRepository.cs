using CleanAssetApi.Domain;

namespace CleanAssetApi.Infrastructure.DBInterfaces
{
    public interface IFakeDesktopRepository
    {
        Task<PagedList<Desktop>> GetAll(DesktopQueryStringParameters desktopQueryStringParameter);
        Task<Desktop> GetDesktopById(Guid DesktopId);
      //  void UpdateDesktopDetails(Desktop Desktop);
        void CreateDesktop(Desktop Desktop);
        void DeleteDesktop(Desktop Desktop);
        

    }
}