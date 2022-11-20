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
    public class Account_GetByUserName
    {
        public class Response
        {
            public DataModel.DomainClasses.Account Account { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public string Username { get; set; }
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
                var _model = _db.Account.Where(x => x.Username == request.Username).SingleOrDefault();

                return new Response
                {
                    Account = _model
                };
            }
        }
    }
}
