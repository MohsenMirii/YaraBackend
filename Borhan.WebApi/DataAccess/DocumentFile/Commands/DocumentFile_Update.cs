using Yara.Infrastructure.Data.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DocumentFile.Commands
{
    public class DocumentFile_Update
    {
        public class Command : IRequest<Response>
        {
            public DataModel.DomainClasses.DocumentFile DocumentFile { get; set; }
        }

        public class Response
        {
            public bool Result { get; set; }
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
                _db.Entry(request.DocumentFile).State = EntityState.Modified;

                await _db.SaveChangesAsync();

                return new Response { Result = true };
            }
        }

    }
}
