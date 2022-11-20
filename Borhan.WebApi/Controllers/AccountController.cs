using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModel.Account;
using DataModel.Common;
using BusinessLogic.BusinessInterface.Account;

namespace Yara.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount_BL _account_BL;

        public AccountController(IAccount_BL account_BL)
        {
            _account_BL = account_BL;
        }

        
        [HttpPost]
        [Route("RegisterAccount")]
        public async Task<ActionResult> RegisterAccount([FromBody] RegisterAccount_VM inputModel)
        {
            inputModel.AccountId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return await _account_BL.RegisterAccount(inputModel);
        }


        
        [HttpPost]
        [Route("ChangePermissionAccount")]
        public async Task<ActionResult> ChangePermissionAccount([FromBody] ChangePermissionAccount_SVM inputModel)
        {
            inputModel.AccountId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return await _account_BL.ChangePermissionAccount(inputModel);
        }

        
        [HttpPost]
        [Route("ChangePasswordByAdmin")]
        public async Task<ActionResult> ChangePasswordByAdmin([FromBody] ChangePasswordByAdminDTO inputModel)
        {
            inputModel.AccountId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return await _account_BL.ChangePasswordByAdmin(inputModel);
        }

        
        [HttpPost]
        [Route("ChangePassword")]
        public ActionResult ChangePassword([FromBody] ChangePasswordDTO inputModel)
        {
            inputModel.AccountId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return _account_BL.ChangePassword(inputModel).Result;
        }

        
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] LoginDTO accountDto)
        {
            return _account_BL.Login(accountDto).Result;
        }

        
        [HttpPost]
        [Route("GetDataList")]
        public async Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel)
        {
            return await _account_BL.GetDataList(inputModel);
        }

        
        [HttpPost]
        [Route("GetAccountPermission")]
        public ActionResult GetAccountPermission()
        {
            long accountId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return _account_BL.GetAccountPermission(accountId).Result;
        }
      
    }
}
