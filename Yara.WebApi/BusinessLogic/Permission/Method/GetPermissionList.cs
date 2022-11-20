using DataAccess.Permission.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Permission.Method
{
    public partial class Permission_BL
    {
        public async Task<ActionResult> GetPermissionList()
        {
            var respone = _mediator.Send(new Permission_Search.Query { InputModel=new DataModel.DomainClasses.Permission { isShow=(int)ShowingStatus.Enable} }).Result.Permission;

            return Ok(new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "OK",
                Result = respone
            });
        }
    }
}
