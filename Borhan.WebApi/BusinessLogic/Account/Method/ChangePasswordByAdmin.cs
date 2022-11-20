using CrossCuttingService.Password;
using DataAccess.Account.Commands;
using DataAccess.Account.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
        public async Task<ActionResult> ChangePasswordByAdmin(ChangePasswordByAdminDTO inputModel)
        {
            try
            {
                BaseResult_VM methodResult = Authentication(inputModel.AccountId, ActionPermission.AdminOP_ChangePassword);
                if (methodResult.ErrorCode != 0)
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
                var account = _mediator.Send(new Account_GetById.Query { PointerID = inputModel.ImpressedAccountId }).Result.Account;

                byte[] salt = null;
                account.Password = inputModel.NewPassword.HashPassword(ref salt);
                account.Salt = salt;
                await _mediator.Send(new Account_Update.Command { Account = account });


                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "عملیات با موفقیت انجام شد."
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
