using BusinessLogic.BusinessInterface;
using BusinessLogic.BusinessInterface.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Analysis.Method
{
    public partial class Analysis_BL : ControllerBase, IGenericRepository_BL<DataModel.DomainClasses.Analysis>
    {
        private readonly IMediator _mediator;
        IAccount_BL _account_BL;
        public Analysis_BL(IMediator mediator,IAccount_BL account_BL)
        {
            _mediator = mediator;
            _account_BL = account_BL;
        }
    }
}
