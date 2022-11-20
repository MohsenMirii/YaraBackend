using DataAccess.Company.Queries;
using DataAccess.DocumentFile.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Company.Method
{
    public partial class Company_BL
    {
         public async Task<ActionResult> Search([FromBody] DataModel.DomainClasses.Company inputModel)
        {
            try
            {
              
              //  var result = _mediator.Send(new Company_Search.Query { InputModel = inputModel }).Result.Company;
               // var result = _mediator.Send(new Company_Search.Query { InputModel = inputModel }).Result.Company;

                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "عملیات با موفقیت انجام گردید.",
                   // Result = result
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی رخ داده است لطفا با مدیر سیستم تماس بگیرید."
                });
            }

        }
    }
}
