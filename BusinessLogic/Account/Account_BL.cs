using BusinessLogic.BusinessInterface.Account;
using DataAccess.Config;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL : ControllerBase, IAccount_BL
    {
         AppSetting _appSettings;
        private readonly IMediator _mediator;
        public Account_BL(
            IMediator mediator,
            IOptions<AppSetting> appSettings)
        {
            _mediator = mediator;
            _appSettings = appSettings.Value;
        }
    }
}
