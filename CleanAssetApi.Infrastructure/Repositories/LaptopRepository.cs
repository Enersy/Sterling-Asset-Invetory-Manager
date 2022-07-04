using CleanAssetApi.Domain;
using CleanAssetApi.Domain.Exceptions;
using CleanAssetApi.Infrastructure.Data;
using CleanAssetApi.Infrastructure.DBInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanAssetApi.Infrastructure.Repositories
{
    public class LaptopRepository :BaseRepository<Laptop>, ILaptopRepository
    {
        public LaptopRepository(APIDbContext repositoryContext): base(repositoryContext)
        {
        }

        public void CreateLaptop(Laptop Laptop)
        {
            Create(Laptop);
        }

        public void DeleteLaptop(Laptop Laptop)
        {
            Delete(Laptop);
        }

        public async Task<PagedList<Laptop>> GetAll(LaptopQueryStringParameters laptopQueryStringParameter)
        {
            var queryResult =FindAll()
                 .Include(assinfo => assinfo.AssetInfo)
                 .Include(acu => acu.Custodian)
                 .Include(clu => clu.Custodian.Location) as IQueryable<Laptop> ;

            SearchByAssetTag(ref queryResult,laptopQueryStringParameter.AssetTag);

            return PagedList<Laptop>.ToPagedList(
                queryResult,
              laptopQueryStringParameter.PageNumber,
              laptopQueryStringParameter.PageSize
              );

        }

        private void SearchByAssetTag(ref IQueryable<Laptop> laptops ,string assetTag)
        {
            if (!laptops.Any() || string.IsNullOrWhiteSpace(assetTag))
                return;
            laptops = laptops.Where(l => l.AssetInfo.AssetNumber.ToLower().Contains(assetTag.Trim().ToLower()));
        }

        public async Task<Laptop> GetLaptopById(Guid LaptopId)
        {
            var lap = await FindByCondition(Laptop => Laptop.Id.Equals(LaptopId))
                 .Include(Ac => Ac.Custodian)
                 .Include(assinfo => assinfo.AssetInfo)
                 .FirstOrDefaultAsync();
            if (lap == null)
            {
                throw new AssetDoesNotExistException("No Asset Found");
            }
            else
            {
                return lap;
            }
        }

        public void UpdateLaptop(Laptop Laptop)
        {
            Update(Laptop);
        }
    }
}
