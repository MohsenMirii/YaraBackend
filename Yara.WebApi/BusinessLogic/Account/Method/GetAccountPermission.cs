using DataAccess.AccountPermission.Queries;
using DataAccess.Permission.Queries;
using DataModel.DomainClasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;
using System.Linq;

namespace BusinessLogic.Account.Method
{

    public partial class Account_BL
    {
        public async Task<ActionResult> GetAccountPermission(long accountId)
        {
            
            List<AccountPermission> _accountPermission = _mediator.Send(new AccountPermission_Search.Query {Where=x=>x.AccountId==accountId }).Result.AccountPermission;

            List<MenuPermission_VM> PermissionListVM = new List<MenuPermission_VM>();
            foreach (var item in _accountPermission)
            {
                DataModel.DomainClasses.Permission _permission = _mediator.Send(new Permission_GetById.Query { PointerID = item.PermissionId }).Result.Permission;
                if (_permission.isShow==(int)ShowingStatus.Disable)
                {
                    continue;
                }
                PermissionListVM.Add(new MenuPermission_VM
                {
                    ActionCode = _permission.Id,
                    SuperActionCode = _permission.ParentId,
                    ActionName = _permission.ActionName,
                    MenuUrl = _permission.MenuUrl,
                    Icon = _permission.Icon,
                    Priority=_permission.Priority
                });
            }

            PermissionListVM = PermissionListVM.OrderBy(x => x.Priority).ToList();
            return Ok(new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "عملیات با موفقیت انجام گردید.",
                Result= PermissionListVM
            });
        }
    }
}
