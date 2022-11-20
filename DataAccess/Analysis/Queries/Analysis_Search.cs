using Yara.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Common;
using System;
using System.Linq.Expressions;

namespace DataAccess.Analysis.Queries
{
    public class Analysis_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Analysis> Analysis { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public Expression<Func<DataModel.DomainClasses.Analysis, bool>> Where { get; set; } = null;
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly YaraContext _db;
            private DbSet<DataModel.DomainClasses.Analysis> _dbSet;
            public Handler(YaraContext db)
            {
                _db = db;
                _dbSet = _db.Set<DataModel.DomainClasses.Analysis>();
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                //var query = _db.Analysis.Where(x => 1 == 1);

                //if (string.IsNullOrEmpty(request.InputModel.KeyWord) && request.InputModel.Id > 0)
                //{
                //    query = query.Where(x => x.Id == request.InputModel.Id);
                //}

                //if (!string.IsNullOrEmpty(request.InputModel.KeyWord) && request.InputModel.Id > 0)
                //{
                //    query = query.Where(x => x.KeyWord.Contains(request.InputModel.KeyWord) && x.Id != request.InputModel.Id);
                //}
                //else if (!string.IsNullOrEmpty(request.InputModel.KeyWord))
                //{
                //    query = query.Where(x => x.KeyWord.Contains(request.InputModel.KeyWord));
                //}

                //if (!string.IsNullOrEmpty(request.InputModel.Text))
                //{
                //    query = query.Where(x => x.Text.Contains(request.InputModel.Text));
                //}

                //var _model = await query.Include(x => x.Document).OrderByDescending(x => x.Id).ToListAsync();

                //return new Response
                //{
                //    Analysis = _model
                //};

                IQueryable<DataModel.DomainClasses.Analysis> query = _dbSet;

                if (request.Where != null)
                {
                    query = query.Where(request.Where);
                }

                return new Response
                {
                    Analysis = await query.Include(x => x.Document).OrderByDescending(x => x.Id).ToListAsync()
                };
            }
        }
    }
}
