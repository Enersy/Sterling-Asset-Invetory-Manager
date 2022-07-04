using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Domain.Exceptions
{
    public class AssetDoesNotExistException:Exception
    {
        public AssetDoesNotExistException()
        {

        }

        public AssetDoesNotExistException(string Id)
            : base(String.Format("Asset With This Id does not Exist: {0}", Id))
        {

        }
    }
}
