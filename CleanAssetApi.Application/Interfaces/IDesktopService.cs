using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Application.Interfaces
{
    public interface IDesktopService
    {
        Task<PagedList<Desktop>> GetDesktops(DesktopQueryStringParameters desktopQueryStringParameters);
        Task<Desktop> GetDesktopById(Guid DesktopId);
        void UpdateDesktopDetails(Desktop Desktop);
        void CreateDesktop(Desktop Desktop);
        void DeleteDesktop(Desktop Desktop);
    }
}
