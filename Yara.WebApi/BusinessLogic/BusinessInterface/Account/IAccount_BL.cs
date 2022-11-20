using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.BusinessInterface.Account
{
    public interface IAccount_BL
    {
        Task<ActionResult> RegisterAccount([FromBody] RegisterAccount_VM inputModel);
        Task<ActionResult> ChangePermissionAccount([FromBody] ChangePermissionAccount_SVM inputModel);
        Task<ActionResult> ChangePasswordByAdmin(ChangePasswordByAdminDTO inputModel);
        Task<ActionResult> ChangePassword(ChangePasswordDTO inputModel);
        BaseResult_VM Authentication(long AccountId, ActionPermission actionPermission);
        Task<ActionResult> Login(LoginDTO inputModel);
        Task<ActionResult> GetAccountPermission(long accountId);
        Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel);


    }
}
