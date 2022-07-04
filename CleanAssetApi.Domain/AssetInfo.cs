using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain
{
    public class AssetInfo
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }=string.Empty;

        public string ModelName { get; set; }=string.Empty;

        public string ModelNumber { get; set; }=string.Empty;

        public string AssetNumber { get; set; }=string.Empty;

        public string Brand { get; set; }=string.Empty;

        public string Remark { get; set; }=string.Empty;

        public string Status { get; set; }=string.Empty;

        public string underwarranty { get; set; }=string.Empty;

        public DateTime YearOfManufacture { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
