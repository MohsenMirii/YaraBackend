using BusinessLogic.BusinessInterface;
using BusinessLogic.BusinessInterface.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Company.Method
{
    public partial class Company_BL : ControllerBase, IGenericRepository_BL<DataModel.DomainClasses.Company>
    {
        private readonly IMediator _mediator;
        IAccount_BL _account_BL;
        public Company_BL(IMediator mediator,IAccount_BL account_BL)
        {
            _mediator = mediator;
            _account_BL = account_BL;
        }
    }
}
