using Yara.Infrastructure.Data.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Permission.Queries
{
    public class Permission_GetById
    {
        public class Response
        {
            public DataModel.DomainClasses.Permission Permission { get; set; }
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
                var _model = _db.Permission.Find(request.PointerID);
                
                return new Response
                {
                    Permission = _model
                };
            }
        }
    }
}
