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
    public class Account_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Account> Account { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public DataModel.DomainClasses.Account InputModel { get; set; }
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
                var result = _db.Account.Where(x => 1 == 1);

                if (!string.IsNullOrEmpty(request.InputModel.Email))
                {
                    result = result.Where(x => x.Email.Contains(request.InputModel.Email));
                }

                if (!string.IsNullOrEmpty(request.InputModel.Username))
                {
                    result = result.Where(x => x.Username.Contains(request.InputModel.Username));
                }

                var model = result.ToListAsync();
                return new Response
                {
                    Account = model.Result
                };
            }
        }
    }
}
