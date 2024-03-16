using AutoMapper;
using Ecom_Shopper.App.Dto;
using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.Service.Interface;
using Ecom_Shopper.App.ViewModel;
using Ecom_Shopper.Domain.Interface;
using Ecom_Shopper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IPaginationService<ProductDto, Product> _paginationService;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper, IPaginationService<ProductDto, Product> paginationService)
        {
            _mapper = mapper;
            _repository = repository;
            _paginationService = paginationService;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            var data = _mapper.Map<Product>(createProductDto);
            var result = await _repository.CreateAsync(data);
            var Result = _mapper.Map<ProductDto>(result);
            return Result;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _repository.GetByIdAsync(x => x.ProductId == id);
            await _repository.DeleteAsync(result);

        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetByFilterAsync(string? productCategory,string? productName)
        {
            var data = await _repository.GetAllAsync();
            IEnumerable<Product> product = data;
            if(productCategory != null)
            {
                product = product.Where(x=>x.ProductCategory== productCategory);
            }
            if(productName != null)
            {
                product = product.Where(x=>x.ProductName == productName);
            }
            var Result = _mapper.Map<List<ProductDto>>(product);
            return Result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(x => x.ProductId == id);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<PaginationVM<ProductDto>> GetPagination(PaginationIM paginationIM)
        {
            var source = await _repository.GetAllProduct();
            var data = _paginationService.Getpagination(source, paginationIM);
            return data;
        }

        public Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            var result = _mapper.Map<Product>(updateProductDto);
            return _repository.UpdateAsync(result);
        }
    }
}
