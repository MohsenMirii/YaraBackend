using Yara.Infrastructure.Data.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.DocumentFile.Queries
{

    public class DocumentFile_GetCount
    {
        public class Response
        {
            public int TotalCountInt { get; set; }
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
                var _model = _db.DocumentFiles.Count();

                return new Response
                {
                    TotalCountInt = _model
                };
            }
        }
    }
}
