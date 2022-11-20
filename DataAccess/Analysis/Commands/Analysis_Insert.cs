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
    public class Analysis_Insert
    {
        public class Command : IRequest<Response>
        {
            public DataModel.DomainClasses.Analysis Analysis { get; set; }
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
                DataModel.DomainClasses.Analysis data = request.Analysis;
                _db.Analysis.Add(data);

                await _db.SaveChangesAsync();

                return new Response
                {
                    PointerID = data.Id
                };
            }
        }
    }
}
