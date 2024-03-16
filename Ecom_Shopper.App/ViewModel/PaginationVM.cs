using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.ViewModel
{
    public class PaginationVM<T>
    {
        public int CurrentPage { get; set; }
        public int Totalpage { get; set; }
        public int PageSize { get; set; }
        public int TotalNoofRecords { get; set; }
        public List<T> Items { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < Totalpage;

        public PaginationVM(int currentPage,int totalPage,int pageSize,int totalNoOfRecords,List<T> items)
        {
            currentPage = CurrentPage;
            totalPage = Totalpage;
            pageSize = PageSize;
            totalNoOfRecords = TotalNoofRecords;
            items = Items;

        }

    }
}
