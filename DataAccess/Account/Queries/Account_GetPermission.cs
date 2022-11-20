using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Account;
using DataModel.Common;

namespace DataAccess.Account.Queries
{
    public class Account_GetPermission
    {
        public class Response
        {
            public List<MenuPermission_VM> MenuPermissionVM { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public long AccountId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly YaraContext _db;
            public Handler(YaraContext db)
            {
                _db = db;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var account = _db.Account.Where(x => x.Id ==request.AccountId)
                  // .Include(x => x.AccountPermission)
                  // .ThenInclude(x => x.Permission)
                  // .Include(x => x.AccountRole)
                  // .ThenInclude(x => x.Role)
                  // .ThenInclude(x => x.RolePermission)
                  // .ThenInclude(x => x.Permission)
                  .SingleOrDefault();

                if (account == null)
                {
                    return null;
                }

                List<MenuPermission_VM> PermissionListVM = new List<MenuPermission_VM>();

                //foreach (var item in account.AccountRole.FirstOrDefault().Role.RolePermission)
                //{
                //    var permission = _db.Permission.Where(xx => xx.Id == item.PermissionId).FirstOrDefault();
                //    PermissionListVM.Add(new MenuPermission_VM
                //    {
                //        //ActionCode = permission.Id,
                //        //ActionName = permission.ActionName,
                //        //Icon = permission.Icon,
                //        //isShow = permission.isShow,
                //        //KeyWord = permission.KeyWord,
                //        //MenuUrl = permission.MenuUrl,
                //        //SuperActionCode = permission.SuperId
                //    });
                //}
                

                return new Response
                {
                    MenuPermissionVM = PermissionListVM
                };
            }
        }
    }
}
