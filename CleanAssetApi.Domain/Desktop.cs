using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public class Desktop : ComputerAsset
    {
        public Guid Id { get; set; }
        public CpuMonitorInfo CpuMonitorInfo { get; set; }
        public string HostName { get; set; }=string.Empty;
        public AssetCustodian Custodian { get; set; }

    }
}
