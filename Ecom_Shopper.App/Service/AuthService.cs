//using Ecom_Shopper.App.Common;
//using Ecom_Shopper.App.InputModel;
//using Ecom_Shopper.App.Service.Interface;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ecom_Shopper.App.Service
//{
//    public class AuthService : IAuthService
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ApplicationUser _applicationUser;
//        public AuthService(UserManager<ApplicationUser> userManager, ApplicationUser applicationUser)
//        {
//            _userManager = userManager;
//            _applicationUser = applicationUser;
//        }

//        public async Task<IEnumerable<IdentityError>> RegisterUser(Register register)
//        {
//            _applicationUser.FirstName = register.FirstName;
//            _applicationUser.LastName = register.LastName;
//            _applicationUser.Email = register.Email;
//            _applicationUser.UserName = register.Email;
//             var result = await _userManager.CreateAsync(_applicationUser,register.Password);
//            if (!result.Succeeded)
//            {
//                await _userManager.AddToRoleAsync(_applicationUser, "ADMIN");
//            }
//            return result.Errors;
//        }
//    }
//}
