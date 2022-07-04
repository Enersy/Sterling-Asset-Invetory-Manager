using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public abstract class ComputerAsset
    {
        public AssetInfo AssetInfo { get; set; }
        public int RamSize { get; set; }
        public string SupportOfficer { get; set; }=string.Empty;
    }
}
