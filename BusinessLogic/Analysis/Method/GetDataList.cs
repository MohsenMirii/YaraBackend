using DataAccess.Analysis.Queries;
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
using DataAccess.Analysis.Commands;

namespace BusinessLogic.Analysis.Method
{
    
    public partial class Analysis_BL
    {
         public async Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel)
        {
            try
            {

                var _dataList = _mediator.Send(new Analysis_GetList.Query { InputModel = inputModel }).Result.Analysis;
                int _dataTotal = _mediator.Send(new Analysis_GetCount.Query { InputModel = inputModel }).Result.TotalCountInt;

                DataList_VM<DataModel.DomainClasses.Analysis> _dataResult = new DataList_VM<DataModel.DomainClasses.Analysis>
                {
                    DataList = _dataList,
                    TotalCountInt = _dataTotal,
                    DataTypeInt = 2
                };

                //foreach (var item in _dataList)
                //{
                //    item.VisitsCount += 1;

                //    await _mediator.Send(new Analysis_Update.Command { Analysis = item });
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
