using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service.Interface
{
    public interface IPaginationService<T,S> where T : class
    {
        PaginationVM<T> Getpagination(List<S> source, PaginationIM paginationIM);
    }
}
