//using Ecom_Shopper.App.Common;
//using Ecom_Shopper.App.InputModel;
//using Ecom_Shopper.App.Service.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using static Ecom_Shopper.App.ApplicationContents;

//namespace Ecom_Shopper.Web.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IAuthService _authService;
//        private APIResponse _response;
//        public UserController(IAuthService authService)
//        {
//            _authService = authService;
//            _response = new APIResponse();
//        }
//        [HttpPost]
//        [Route("Register")]
//        public async Task<ActionResult<APIResponse>>RegisterUSer(Register register)
//        {
//            try
//            {
//                if(!ModelState.IsValid)
//                {
//                    _response.AddError(ModelState.ToString());
//                    _response.Message = CommonMessage.RegistrationFailed;
//                    return _response;
//                }

//                var result = await _authService.RegisterUser(register);
//                _response.StatusCode = System.Net.HttpStatusCode.Created;
//                _response.IsSuccess = true;
//                _response.Message = CommonMessage.RegistrationSuccess;
//                _response.Result = result;
//                return _response;

//            }catch (Exception)
//            {
//                _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
//                _response.AddError(CommonMessage.SystemError);
//                _response.Message = CommonMessage.RegistrationFailed;
//            }
//            return _response;
//        }
//    }
//}
