using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;


namespace DataAccess.Analysis.Commands
{
    public class Analysis_Update
    {
        public class Command : IRequest<Response>
        {
            public DataModel.DomainClasses.Analysis Analysis { get; set; }
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
                _db.Entry(request.Analysis).State = EntityState.Modified;

                await _db.SaveChangesAsync();

                return new Response { Result = true };
            }
        }

    }
}
