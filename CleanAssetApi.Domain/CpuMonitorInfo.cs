using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public class CpuMonitorInfo
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }=string.Empty;
        public string AssetTag { get; set; }=string.Empty;
    }
}
