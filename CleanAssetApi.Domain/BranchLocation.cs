using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public class BranchLocation
    {
        public Guid Id { get; set; }
        public string Region { get; set; }
        public string Branch { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public String City { get; set; }
    }
}
