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
    public class Company_GetList
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Company> Company { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public GetItemDTO InputModel { get; set; }
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
                if (request.InputModel.PageSize != 0)
                {
                    var model = await _db.Company.Include(x => x.Document).OrderByDescending(x => x.Id).Skip(request.InputModel.StartIndex).Take(request.InputModel.PageSize).ToListAsync();

                    return new Response
                    {
                        Company = model
                    };
                }

                var _model = await _db.Company.Include(x => x.Document).OrderByDescending(x => x.Id).ToListAsync();

                return new Response
                {
                    Company = _model
                };
            }
        }
    }
}
