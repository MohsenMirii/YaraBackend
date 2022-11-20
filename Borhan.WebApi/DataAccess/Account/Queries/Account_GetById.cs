using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.Account.Queries
{
    public class Account_GetById
    {
        public class Response
        {
            public DataModel.DomainClasses.Account Account { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public long PointerID { get; set; }
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
                var _model =  _db.Account.Where(x => x.Id == request.PointerID)
                   //.Include(x => x.RolePermission)
                   //.ThenInclude(x => x.Permission)
                   //.Include(x => x.AccountRole)
                   //.ThenInclude(x => x.Role)
                   //.ThenInclude(x => x.RolePermission)
                   //.ThenInclude(x => x.Permission)
                   .SingleOrDefault();

                return new Response
                {
                    Account = _model
                };
            }
        }
    }
}
