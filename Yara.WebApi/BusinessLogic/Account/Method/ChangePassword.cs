using CrossCuttingService.Password;
using DataAccess.Account.Commands;
using DataAccess.Account.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
         public async Task<ActionResult> ChangePassword(ChangePasswordDTO inputModel)
        {
            try
            {
                BaseResult_VM methodResult = Authentication(inputModel.AccountId, ActionPermission.AdminOP_Update);
                if (methodResult.ErrorCode!=0)
                {
                    return Ok(methodResult);
                }

                if (inputModel.NewPassword != inputModel.ConfirmPassword)
                {
                    return BadRequest(new BaseResult_VM
                    {
                        ErrorCode = -2000,
                        ErrorMessage = "تکرار پسوردها با هم تطابق ندارد."
                    });
                }
                var account = _mediator.Send(new Account_GetById.Query { PointerID =inputModel.AccountId }).Result.Account;

                byte[] salt = account.Salt;
                inputModel.PreviousPassword = inputModel.PreviousPassword.HashPassword(ref salt);

                if (account.Password != inputModel.PreviousPassword)
                {
                    return BadRequest(new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "پسورد قبلی به درستی وارد نشده است."
                    });
                }


                account.Password = inputModel.NewPassword.HashPassword(ref salt);
                account.Salt = salt;
               await _mediator.Send(new Account_Update.Command { Account = account });
                

                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "تغییر پسورد با موفقیت انجام گردید."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی در سامانه رخ داده است لطفا با مدیر سیستم تماس بگیرید."
                });

              
            }
        }
    }
}
