using Yara.Infrastructure.Data.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.DocumentFile.Queries
{
    public class DocumentFile_GetById
    {
        public class Response
        {
            public DataModel.DomainClasses.DocumentFile DocumentFile { get; set; }
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

                var _model = _db.DocumentFiles.Find(request.PointerID);

                return new Response
                {
                    DocumentFile = _model
                };
            }
        }
    }
}
