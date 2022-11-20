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
using Newtonsoft.Json;
using DataAccess.Company.Commands;

namespace BusinessLogic.Company.Method
{
    
    public partial class Company_BL
    {
         public async Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel)
        {
            try
            {

                var _dataList = _mediator.Send(new Company_GetList.Query { InputModel = inputModel }).Result.Company;
                int _dataTotal = _mediator.Send(new Company_GetCount.Query { InputModel = inputModel }).Result.TotalCountInt;

                DataList_VM<DataModel.DomainClasses.Company> _dataResult = new DataList_VM<DataModel.DomainClasses.Company>
                {
                    DataList = _dataList,
                    TotalCountInt = _dataTotal,
                    DataTypeInt = 2
                };

                //foreach (var item in _dataList)
                //{
                //    item.VisitsCount += 1;

                //    await _mediator.Send(new Company_Update.Command { Company = item });
                //}
                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "عملیات با موفقیت انجام گردید.",
                    Result = _dataResult
                });
            }
            catch (Exception ex)
            {
                return Ok(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی رخ داده است لطفا با مدیر سیستم تماس بگیرید.",
                    Result = JsonConvert.SerializeObject(ex)
                });
            }

        }
    }
}
