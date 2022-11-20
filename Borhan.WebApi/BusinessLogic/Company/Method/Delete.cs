using BusinessLogic.Account.Method;
using DataAccess.Company.Commands;
using DataAccess.Company.Queries;
using DataAccess.DocumentFile.Commands;
using DataAccess.DocumentFile.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;
using DataModel.Enum;
using Newtonsoft.Json;

namespace BusinessLogic.Company.Method
{
    public partial class Company_BL
    {
        public async Task<ActionResult> Delete(DeleteClassDTO inputModel)
        {
            try
            {
                BaseResult_VM methodResult = _account_BL.Authentication(inputModel.AuthorId, DataModel.Enum.ActionPermission.CompanyOP_Update);
                if (methodResult.ErrorCode != 0)
                {
                    return Ok(methodResult);
                }

                if (inputModel.id <= 0)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "درخواست شما معتبر نمی باشد."
                    });
                }


                var data = _mediator.Send(new Company_GetById.Query { PointerID = inputModel.id }).Result.Company;
                if (data == null)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "درخواست شما معتبر نمی باشد."
                    });
                }

                await _mediator.Send(new Company_DeleteById.Command { PointerID = inputModel.id });

                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "عملیات با موفقیت انجام گردید."
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی رخ داده است لطفا با مدیر سیستم تماس بگیرید.",
                    Result=JsonConvert.SerializeObject(ex)
                });
            }

        }
    }
}
