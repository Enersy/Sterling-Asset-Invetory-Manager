using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Infrastructure
{
    public class DesktopQueryStringParameters:QueryStringParameters
    {
        public string AssetTag { get; set; } = String.Empty;
    }
}
