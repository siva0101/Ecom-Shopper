using Ecom_Shopper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.Domain.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateAsync(Product product);
        Task<List<Product>> GetAllProduct();
    }
}
