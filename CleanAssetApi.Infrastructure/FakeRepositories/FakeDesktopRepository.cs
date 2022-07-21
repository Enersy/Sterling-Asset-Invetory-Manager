using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanAssetApi.Infrastructure.DBInterfaces;

namespace CleanAssetApi.Infrastructure.Repositories
{
    public  class FakeDesktopRepository :IFakeDesktopRepository
    {
        public  IQueryable<Desktop>  desktopsContext = new  List<Desktop>
        {
               new Desktop{
                    AssetInfo = new AssetInfo{
                        ModelName = "HP Prodesk 600",
                        ModelNumber = "HP Prodesk 600",
                        SerialNumber = "CNC123456",
                        Status ="Active",
                        AssetNumber ="SBP123456",
                        CreatedAt = DateTime.UtcNow,
                        Brand = "HP",
                        underwarranty ="NO",
                        Remark ="Okay"
                    },
                    Custodian = new AssetCustodian
                    {
                        Name ="Joseph Audu",
                        Department = "Technology",
                        Location = new BranchLocation
                        {
                            Region = "NorthWest",
                            Branch ="MMWAY",
                            StreetName ="Murtala Muhamed Way",
                            StreetNumber = "110",
                            City = "Kano"
                        }
                    },
                     CpuMonitorInfo = new CpuMonitorInfo{
                        AssetTag = "SBP23456",
                        SerialNumber ="Ujekhoflld" 
                    },
                    SupportOfficer ="Joseph Audu",
                    RamSize = 8,
                    HostName ="KN-MMWAY-D24"
               },
                  new Desktop
                {
                    AssetInfo = new AssetInfo{
                        ModelName = "HP Prodesk 600",
                        ModelNumber = "HP Prodesk 600",
                        SerialNumber = "CNC123456",
                        Status ="Active",
                        AssetNumber ="SBP123456",
                        CreatedAt = DateTime.UtcNow,
                        Brand = "HP",
                        underwarranty ="NO",
                        Remark ="Okay"
                    },
                    Custodian = new AssetCustodian
                    {
                        Name ="Johnson Sunday",
                        Department = "Operation",
                        Location = new BranchLocation
                        {
                            Region = "NorthWest",
                            Branch ="Niger Street",
                            StreetName ="Niger STreet",
                            StreetNumber = "2b",
                            City = "Kano"
                        }
                    },
                    CpuMonitorInfo = new CpuMonitorInfo{
                        AssetTag = "SBP23456",
                        SerialNumber ="Ujekhoflld" 
                    },
                    SupportOfficer ="Joseph Audu",
                    RamSize = 8,
                    HostName ="KN-MMWAY-D25"
                }
        }.AsQueryable<Desktop>();
        

        public async Task<PagedList<Desktop>> GetAll(DesktopQueryStringParameters desktopQueryStringParameters)
        {
            var queryResult = desktopsContext
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

        private  void SearchByAssetTag(ref IQueryable<Desktop> desktops, string assetTag)
        {
            if (!desktops.Any() || string.IsNullOrWhiteSpace(assetTag))
                return;
            desktops = desktops.Where(l => l.AssetInfo.AssetNumber.ToLower().Contains(assetTag.Trim().ToLower()));

        }
         public void CreateDesktop(Desktop Desktop)
        {
            desktopsContext.ToList<Desktop>().Add(Desktop);
        }

        public void DeleteDesktop(Desktop Desktop)
        {
            desktopsContext.ToList<Desktop>().Remove(Desktop);
        }
         public async Task<Desktop> GetDesktopById(Guid DesktopId)
        {
            return await desktopsContext.Where(Desktop => Desktop.Id.Equals(DesktopId))
                 .Include(Ac => Ac.Custodian)
                 .Include(cm=>cm.CpuMonitorInfo)
                 .Include(assinfo => assinfo.AssetInfo)
                 .FirstOrDefaultAsync();
        }

      //  public void UpdateDesktop(Desktop Desktop)
       // {
     //      desktopsContext.ToList<Desktop>(). Update(Desktop);
     //   }

       
    }  
}
