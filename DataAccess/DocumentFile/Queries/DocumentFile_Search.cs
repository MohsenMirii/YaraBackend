using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;
using DataModel.Enum;

namespace DataAccess.DocumentFile.Queries
{
    public class DocumentFile_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.DocumentFile> DocumentFile { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public DataModel.DomainClasses.DocumentFile InputModel { get; set; }
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
                var _query = _db.DocumentFiles.Where(x => 1 == 1);

                if (request.InputModel.Id>0)
                {
                    _query = _query.Where(x => x.Id == request.InputModel.Id);
                }

                

                if (request.InputModel.DocumentTypeInt > 0)
                {
                    _query = _query.Where(x => x.DocumentTypeInt == request.InputModel.DocumentTypeInt);
                }
                var _model = _query.ToList();

                return new Response
                {
                    DocumentFile = _model
                };
            }
        }
    }
}
