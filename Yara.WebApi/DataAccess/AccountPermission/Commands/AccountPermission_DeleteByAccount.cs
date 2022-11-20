using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.AccountPermission.Commands
{
    public class AccountPermission_DeleteByAccount
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
               // DataModel.DomainClasses.AccountPermission data = _db.AccountPermissions.Find(request.PointerID);

                _db.AccountPermissions.RemoveRange(_db.AccountPermissions.Where(x=>x.AccountId== request.PointerID).ToList());

                await _db.SaveChangesAsync();

                return new Response
                {
                    IsSuccess = true
                };
            }
        }
    }
}
