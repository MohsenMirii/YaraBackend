using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessInterface
{
    public interface IPermission_BL 
    {
        Task<ActionResult> GetPermissionList();
    }
}
