using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain.Exceptions
{
    public class AssetExistException:Exception
    {
        public AssetExistException()
        {

        }

        public AssetExistException(string Id)
            : base(String.Format("Asset With This Id Already Exist: {0}", Id))
        {

        }
    }
}
