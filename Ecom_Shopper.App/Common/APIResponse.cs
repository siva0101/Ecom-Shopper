using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Common
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public List<APIError> Errors { get; set; }
        public List<APIWarning> Warnings { get; set; }


        public void AddError(string errorMessage)
        {
            APIError error = new APIError(description: errorMessage);
            Errors.Add(error);
        }

        public void AddWarnings(string warningMessage)
        {
            
        }

    }
}
