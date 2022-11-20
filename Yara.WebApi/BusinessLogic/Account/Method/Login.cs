using CrossCuttingService.Password;
using DataAccess.Account.Queries;
using DataAccess.AccountPermission.Queries;
using DataAccess.Permission.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
        public async Task<ActionResult> Login(LoginDTO inputModel)
        {
            try
            {

                var account = _mediator.Send(new Account_GetByUserName.Query { Username = inputModel.Username }).Result.Account;
                if (account == null)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "نام کاربری وارد شده معتبر نمی باشد"
                    });
                }

                var salt = account.Salt;
                var password = inputModel.Password.HashPassword(ref salt);
                if (account.Password != password)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "پسورد وارد شده صحیح نمی باشد"
                    });
                }

                string token = CreateToken(account);

                List<MenuPermission_VM> PermissionListVM = new List<MenuPermission_VM>();

                List<DataModel.DomainClasses.AccountPermission> _accountPermission = _mediator.Send(new AccountPermission_Search.Query { Where=x=>x.AccountId==account.Id}).Result.AccountPermission;
                foreach (var item in _accountPermission)
                {
                    var permission = _mediator.Send(new Permission_GetById.Query { PointerID = item.PermissionId }).Result.Permission;
                    PermissionListVM.Add(new MenuPermission_VM
                    {
                        ActionCode = permission.Id,
                        ActionName = permission.ActionName,
                        Icon = permission.Icon,
                        isShow = permission.isShow,
                        KeyWord = permission.KeyWord,
                        MenuUrl = permission.MenuUrl,
                        SuperActionCode = permission.ParentId
                    });
                }

                Login_VM _loginVM = new Login_VM
                {
                    Token = token,
                    PermissionListVM = PermissionListVM,
                };

                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "OK",
                    Result = _loginVM
                });

            }
            catch (Exception ex)
            {
                return Ok(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی در سامانه رخ داده است لطفا مجددا اقدام نمایید.",
                    Result = JsonConvert.SerializeObject(ex)
                });
            }
        }
    }
}
