using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Permission.Queries
{
    public class Permission_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Permission> Permission { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public DataModel.DomainClasses.Permission InputModel { get; set; }
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

                var _model = _db.Permission.Where(x => 1 == 1);

                if (request.InputModel.isShow != 0)
                {
                    _model = _model.Where(x => x.isShow == request.InputModel.isShow);
                }

                return new Response
                {
                    Permission = await _model.OrderByDescending(x => x.Id).ToListAsync()
                };
            }
        }
    }
}
