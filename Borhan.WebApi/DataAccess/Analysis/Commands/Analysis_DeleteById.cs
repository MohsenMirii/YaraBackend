using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.Company.Commands
{
    public class Company_DeleteById
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
                DataModel.DomainClasses.Company data= _db.Company.Find(request.PointerID);
                if (data.Document != null)
                {
                    _db.DocumentFiles.RemoveRange(data.Document);
                }
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
