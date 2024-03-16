using Ecom_Shopper.App.Common;
using Ecom_Shopper.App.InputModel;
using Ecom_Shopper.App.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Shopper.App.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser AppUser;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(Register register)
        {
            AppUser.FirstName = register.FirstName;
            AppUser.LastName = register.LastName;
            AppUser.Email = register.Email;
            AppUser.UserName = register.Email;

            var result = await _userManager.CreateAsync(AppUser, register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(AppUser, "ADMIN");
            }
            return result.Errors;
        }
    }
}
