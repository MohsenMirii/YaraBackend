using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.Permission.Queries
{
    public class Permision_GetList
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Permission> Permission { get; set; }
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
                    var model = await _db.Permission.OrderByDescending(x => x.Id).Skip(request.InputModel.StartIndex).Take(request.InputModel.PageSize).ToListAsync();

                    return new Response
                    {
                        Permission = model
                    };
                }

                var _model = await _db.Permission.OrderByDescending(x => x.Id).ToListAsync();

                return new Response
                {
                    Permission = _model
                };
            }
        }
    }
}
