using Yara.Infrastructure.Data.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DocumentFile.Commands
{
    public class DocumentFile_DeleteById
    {
        public class Command : IRequest<Response>
        {
            public long PointerID { get; set; }

        }
        public class Response
        {
            public bool IsSuccess { get; set; }
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
                DataModel.DomainClasses.DocumentFile data = _db.DocumentFiles.Find(request.PointerID);

                _db.Entry(data).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return new Response
                {
                    IsSuccess = true
                };
            }
        }
    }
}
