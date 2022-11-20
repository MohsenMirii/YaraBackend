using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.Company.Queries
{
    public class Company_GetById
    {
        public class Response
        {
            public DataModel.DomainClasses.Company Company { get; set; }
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
                var _model = _db.Company.Include(x => x.Document).Single(x => x.Id == request.PointerID);

                return new Response
                {
                    Company = _model
                };
            }
        }
    }
}
