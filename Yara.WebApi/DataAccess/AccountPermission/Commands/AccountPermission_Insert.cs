using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;

namespace DataAccess.AccountPermission.Commands
{
    public class AccountPermission_Insert
    {
        public class Command : IRequest<Response>
        {
            public DataModel.DomainClasses.AccountPermission AccountPermission { get; set; }
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
                DataModel.DomainClasses.AccountPermission AccountPermission = request.AccountPermission;
                _db.AccountPermissions.Add(AccountPermission);

                await _db.SaveChangesAsync();

                return new Response
                {
                    PointerID = AccountPermission.Id
                };
            }
        }
    }
}
