using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanAssetApi.Infrastructure.DBInterfaces;

namespace CleanAssetApi.Infrastructure.Repositories
{
    public class DesktopRepository :BaseRepository<Desktop>, IDesktopRepository
    {
        public DesktopRepository(APIDbContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateDesktop(Desktop Desktop)
        {
            Create(Desktop);
        }

        public void DeleteDesktop(Desktop Desktop)
        {
            Delete(Desktop);
        }

        public async Task<PagedList<Desktop>> GetAll(DesktopQueryStringParameters desktopQueryStringParameters)
        {
            var queryResult = FindAll()
                .Include(assinfo => assinfo.AssetInfo)
                .Include(acu => acu.Custodian)
                .Include(cm => cm.CpuMonitorInfo)
                .Include(clu => clu.Custodian.Location) as IQueryable<Desktop> ;

            SearchByAssetTag(ref queryResult, desktopQueryStringParameters.AssetTag);

            return  PagedList<Desktop>.ToPagedList(
               queryResult,
                desktopQueryStringParameters.PageNumber,
                desktopQueryStringParameters.PageSize
                );
        }

        private void SearchByAssetTag(ref IQueryable<Desktop> desktops, string assetTag)
        {
            if (!desktops.Any() || string.IsNullOrWhiteSpace(assetTag))
                return;
            desktops = desktops.Where(l => l.AssetInfo.AssetNumber.ToLower().Contains(assetTag.Trim().ToLower()));

        }

        public async Task<Desktop> GetDesktopById(Guid DesktopId)
        {
            return await FindByCondition(Desktop => Desktop.Id.Equals(DesktopId))
                 .Include(Ac => Ac.Custodian)
                 .Include(cm=>cm.CpuMonitorInfo)
                 .Include(assinfo => assinfo.AssetInfo)
                 .FirstOrDefaultAsync();
        }

        public void UpdateDesktop(Desktop Desktop)
        {
            Update(Desktop);
        }

    }
}
