using CleanAssetApi.Domain;
using CleanAssetApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAssetApi.Application.Interfaces
{
    public interface ILaptopService
    {
        Task<PagedList<Laptop>> GetLaptops(LaptopQueryStringParameters laptopQueryStringParameter);
        Task<Laptop> GetLaptopById(Guid LaptopId);
        void UpdateLaptopDetails(Laptop laptop);
        void CreateLaptop(Laptop laptop);
        void DeleteLaptop(Laptop laptop);
    }
       
}
