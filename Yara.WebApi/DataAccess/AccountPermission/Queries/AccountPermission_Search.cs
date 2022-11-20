using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;
using System.Linq.Expressions;
using System;

namespace DataAccess.AccountPermission.Queries
{
    public class AccountPermission_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.AccountPermission> AccountPermission { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public Expression<Func<DataModel.DomainClasses.AccountPermission, bool>> Where { get; set; } = null;
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly YaraContext _db;
            private DbSet<DataModel.DomainClasses.AccountPermission> _dbSet;
            public Handler(YaraContext db)
            {
                _db = db;
                _dbSet = _db.Set<DataModel.DomainClasses.AccountPermission>();
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {

                IQueryable<DataModel.DomainClasses.AccountPermission> query = _dbSet;

                if (request.Where != null)
                {
                    query = query.Where(request.Where);
                }

                return new Response
                {
                    AccountPermission = await query.OrderByDescending(x => x.Id).ToListAsync()
                };

            }
        }
    }
}
