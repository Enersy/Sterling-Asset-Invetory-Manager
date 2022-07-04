using CleanAssetApi.Domain;

namespace CleanAssetApi.Infrastructure.DBInterfaces
{
    public interface IDesktopRepository:IBaseRepository<Desktop>
    {
        Task<PagedList<Desktop>> GetAll(DesktopQueryStringParameters desktopQueryStringParameters);
        Task<Desktop> GetDesktopById(Guid DesktopId);
        void CreateDesktop(Desktop Desktop);
        void UpdateDesktop(Desktop Desktop);
        void DeleteDesktop(Desktop Desktop);
    }
}
