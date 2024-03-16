using AutoMapper;
using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.Service.Interface;
using Ecom_Shopper.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service
{
    public class PaginationService<T, S> : IPaginationService<T, S> where T : class
    {
        private readonly IMapper _mapper;
        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public PaginationVM<T> Getpagination(List<S> source, PaginationIM paginationIM)
        {
            var currentPage = paginationIM.PageNumber;

            var pageSize = paginationIM.PageSize;

            var totalNoOfPage = source.Count;

            var totalPage = (int)Math.Ceiling(totalNoOfPage / (double)pageSize);

            var result = source.Skip((paginationIM.PageNumber -1)*(paginationIM.PageSize)).Take(paginationIM.PageSize).ToList();

            var item = _mapper.Map<List<T>>(result);

            PaginationVM<T> paginationVM = new PaginationVM<T>(currentPage, pageSize, totalNoOfPage, totalPage, item);

            return paginationVM;
        }
    }
}
