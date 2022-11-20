using DataAccess.Account.Queries;
using DataAccess.AccountPermission.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;
using DataAccess.AccountPermission.Queries;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
        public async Task<ActionResult> ChangePermissionAccount([FromBody] ChangePermissionAccount_SVM inputModel)
        {
            BaseResult_VM methodResult = Authentication(inputModel.AccountId, ActionPermission.RullsAndPermissionsOP_Update);
            if (methodResult.ErrorCode != 0)
            {
                return Ok(methodResult);
            }

            DataModel.DomainClasses.Account _account = _mediator.Send(new Account_GetById.Query { PointerID = inputModel.ImpressedAccountId }).Result.Account;
            if (_account == null || inputModel.AccountPermissions.Count == 0)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، درخواست شما معتبر نمی باشد لطفا با مدیر سیستم تماس بگیرید."
                });
            }


            var _response = _mediator.Send(new AccountPermission_GetList.Query { InputModel = new GetItemDTO { PointerIdLng = _account.Id } }).Result.AccountPermission;

            bool isSuccess = _mediator.Send(new AccountPermission_DeleteByAccount.Command { PointerID = _account.Id }).Result.IsSuccess;
            if (isSuccess == false)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی در سامانه رخ داده است لطفا مجددا اقدام نمایید."
                });
            }

            //foreach (var item in _response)
            //{
            //    bool isSuccess = _mediator.Send(new AccountPermission_DeleteByAccount.Command { PointerID = item.Id }).Result.IsSuccess;
            //    if (isSuccess == false)
            //    {
            //        return BadRequest(new BaseResult_VM
            //        {
            //            ErrorCode = -1000,
            //            ErrorMessage = "کاربر گرامی، خطایی در سامانه رخ داده است لطفا مجددا اقدام نمایید."
            //        });
            //    }
            //}


            foreach (var item in inputModel.AccountPermissions)
            {
               
                await _mediator.Send(new AccountPermission_Insert.Command
                {
                    AccountPermission = new DataModel.DomainClasses.AccountPermission
                    {
                        AccountId = inputModel.ImpressedAccountId,
                        PermissionId = item,
                        Status = (int)AccountPermissionStatus.Active,
                        InsertDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    }
                });
            }

            return Ok(new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "عملیات با موفقیت انجام گردید."

            });
        }
    }
}
