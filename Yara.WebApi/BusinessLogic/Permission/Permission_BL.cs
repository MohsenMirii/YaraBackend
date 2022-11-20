using BusinessLogic.BusinessInterface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Permission.Method
{
    public partial class Permission_BL : ControllerBase, IPermission_BL
    {
        private readonly IMediator _mediator;
        public Permission_BL(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
