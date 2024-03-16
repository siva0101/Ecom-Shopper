using Ecom_Shopper.App.InputModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service.Interface
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> RegisterUser(Register register);
    }
}
