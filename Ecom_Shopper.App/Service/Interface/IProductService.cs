using Ecom_Shopper.App.Dto;
using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service.Interface
{
    public interface IProductService
    {
        Task<PaginationVM<ProductDto>> GetPagination(PaginationIM paginationIM);
        Task<ProductDto> CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetByFilterAsync(string? productCategory,string? productName);
        Task<ProductDto> GetByIdAsync(int id);
    }
}
