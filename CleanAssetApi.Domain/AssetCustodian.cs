using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public class AssetCustodian
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Department { get; set; }=string.Empty;
        public BranchLocation Location { get; set; }
    }
}
