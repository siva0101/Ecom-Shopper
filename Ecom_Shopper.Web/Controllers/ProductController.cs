using Ecom_Shopper.App.Common;
using Ecom_Shopper.App.Dto;
using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.Service;
using Ecom_Shopper.App.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.Xml;
using static Ecom_Shopper.App.ApplicationContents;

namespace Ecom_Shopper.Web.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IWebHostEnvironment _environment;
        private APIResponse _response;
        public ProductController(IProductService service, IWebHostEnvironment environment)
        {
            _environment = environment;
            _service = service;
            _response = new APIResponse();
        }
        [HttpPost]
        [Route("UploadProducts")]
        public async Task<ActionResult<APIResponse>> Create(CreateProductDto createProductDto)
        {
            try
            {

                foreach (var file in createProductDto.files)
                {

                    var filePath = Path.Combine(_environment.ContentRootPath + "/ProductImage", file.FileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    createProductDto.ProductImage = file.FileName;
                    createProductDto.ImageFilePath = filePath;


                    var result = await _service.CreateAsync(createProductDto);
                            _response.StatusCode = HttpStatusCode.OK;
                            _response.IsSuccess = true;
                            _response.Message = CommonMessage.CreateOperationSuccess;
                            _response.Result = result;
                }
                return _response;
            }
            catch (DbUpdateException ex)
            {
                // Log or inspect ex.InnerException for details
                Console.WriteLine(ex.InnerException);
            }

            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        
        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var result = await _service.GetAllAsync();
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpGet]
        [Route("FilterByProName")]
        public async Task<ActionResult<APIResponse>>GetByFilterAsync(string? productCategory,string? productName)
        {
            try
            {
                var result = await _service.GetByFilterAsync(productCategory,productName);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.FilterOpeationSuccess;
                _response.Result = result;
            }
            catch
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
                _response.Message = CommonMessage.FilterOpeationFailed;
            }
            return _response;
        }
        [HttpPost]
        [Route("Pagination")]
        public async Task<ActionResult<APIResponse>>GetPagination(PaginationIM paginationIM)
        {
            try
            {
                var result = await _service.GetPagination(paginationIM);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.PaginationOpeationsuccess;
                _response.Result = result;
            }
            catch
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
                _response.Message = CommonMessage.PaginationOpeationFailed;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<APIResponse>> GetByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
            }
            return _response;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<APIResponse>> Update(UpdateProductDto updateProductDto)
        {
            try
            {
                foreach (var file in updateProductDto.files)
                {
                    string path = Path.Combine(_environment.ContentRootPath + "/Image", file.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    updateProductDto.ProductImage = file.FileName;
                    updateProductDto.ImageFilePath = path;

                    await _service.UpdateAsync(updateProductDto);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Message = CommonMessage.UpdateOperationSuccess;
                }
                return _response;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
                _response.Message = CommonMessage.UpdateOperationFailed;
            }
            return _response;
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Message = CommonMessage.DeleteOpeationFailed;
                    return _response;
                }
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.Message = CommonMessage.DeleteOpeationFailed;
                    return _response;
                }
                await _service.DeleteAsync(id);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Message = CommonMessage.DeleteOperationSuccess;
                _response.Result = result;
            }
            catch
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddError(CommonMessage.SystemError);
                _response.Message = CommonMessage.DeleteOpeationFailed;
            }
            return _response;
        }


    }
}
    

