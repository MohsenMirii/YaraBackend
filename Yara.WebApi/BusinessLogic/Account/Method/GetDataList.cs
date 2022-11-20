using DataAccess.Account.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;
using DataAccess.AccountPermission.Queries;

namespace BusinessLogic.Account.Method
{
    public class AccountGetData_VM
    {
        public AccountGetData_VM()
        {
            Account = new DataModel.DomainClasses.Account();
            AccountPermission = new List<DataModel.DomainClasses.AccountPermission>();
        }
        public DataModel.DomainClasses.Account Account { get; set; }
        public List<DataModel.DomainClasses.AccountPermission> AccountPermission { get; set; }

    }
    public partial class Account_BL
    {
        public async Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel)
        {
            var accounts = _mediator.Send(new Account_GetList.Query { InputModel = new DataModel.Common.GetItemDTO { PageSize = 0 } }).Result.Account;
            if (accounts == null)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربری تاکنون ثبت نام نشده است"
                });
            }

            List<AccountGetData_VM> _accountGetDataListVM = new List<AccountGetData_VM>();
            foreach (var item in accounts)
            {
                var response = _mediator.Send(new AccountPermission_Search.Query {Where=x=>x.AccountId==item.Id }).Result.AccountPermission;

                _accountGetDataListVM.Add(new AccountGetData_VM
                {
                    Account = item,
                    AccountPermission = response
                });


            }

            return Ok(new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "کاربر گرامی، شما قبلا ثبت نام کرده اید",
                Result = _accountGetDataListVM
            });
        }
    }
}
