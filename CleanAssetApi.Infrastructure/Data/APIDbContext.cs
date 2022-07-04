using CleanAssetApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Infrastructure.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<AssetInfo> AssetInfo { get; set; }

        public DbSet<AssetCustodian> AssetCustodians { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Desktop> Desktops { get; set; }


        public DbSet<BranchLocation> BranchLocations { get; set; }
        public DbSet<CpuMonitorInfo> CpuMonitorInfos { get; set; }

    }
}
