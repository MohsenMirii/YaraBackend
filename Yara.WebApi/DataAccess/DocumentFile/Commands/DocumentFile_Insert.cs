using Yara.Infrastructure.Data.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.DocumentFile.Commands
{
    public class DocumentFile_Insert
    {
        public class Command : IRequest<Response>
        {
            public DataModel.DomainClasses.DocumentFile DocumentFile { get; set; }
        }
        public class Response
        {
            public long PointerID { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly YaraContext _db;
            public Handler(YaraContext db)
            {
                _db = db;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                DataModel.DomainClasses.DocumentFile DocumentFile = request.DocumentFile;
                _db.DocumentFiles.Add(DocumentFile);

                await _db.SaveChangesAsync();

                return new Response
                {
                    PointerID = DocumentFile.Id
                };
            }
        }
    }
}
