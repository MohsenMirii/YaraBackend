using DataAccess.Account.Queries;
using DataAccess.AccountPermission.Queries;
using Newtonsoft.Json;
using System;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
        public BaseResult_VM Authentication(long AccountId, ActionPermission actionPermission)
        {
            try
            {
                return new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "کاربر به این بخش دسترسی دارد."
                };


                var _account = _mediator.Send(new Account_GetById.Query { PointerID = AccountId }).Result.Account;

                if (_account.Id == 1)
                {
                    return new BaseResult_VM
                    {
                        ErrorCode = 0,
                        ErrorMessage = "کاربر به این بخش دسترسی دارد."
                    };
                }

                
                var permission = _mediator.Send(new AccountPermission_Search.Query {Where=x=>x.AccountId==_account.Id && x.PermissionId==(int)actionPermission }).Result.AccountPermission;
                if (permission == null)
                {
                    return new BaseResult_VM
                    {
                        ErrorCode = -1372,
                        ErrorMessage = "کاربر گرامی، شما به این بخش دسترسی ندارید، لطفا با مدیر سیستم تماس بگیرید."
                    };
                }


                return new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "کاربر به این بخش دسترسی دارد."
                };
            }
            catch (Exception ex)
            {
                return new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی در سامانه رخ داده است لطفا با مدیر سیستم تماس بگیرید.",
                    Result = JsonConvert.SerializeObject(ex)
                };
            }
        }
    }
}
