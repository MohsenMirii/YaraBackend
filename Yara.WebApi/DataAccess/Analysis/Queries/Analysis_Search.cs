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

namespace DataAccess.Company.Queries
{
    public class Company_Search
    {
        public class Response
        {
            public List<DataModel.DomainClasses.Company> Company { get; set; }
        }

        public class Query : IRequest<Response>
        {
            public Expression<Func<DataModel.DomainClasses.Company, bool>> Where { get; set; } = null;
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly YaraContext _db;
            private DbSet<DataModel.DomainClasses.Company> _dbSet;
            public Handler(YaraContext db)
            {
                _db = db;
                _dbSet = _db.Set<DataModel.DomainClasses.Company>();
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                //var query = _db.Company.Where(x => 1 == 1);

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
                //    Company = _model
                //};

                IQueryable<DataModel.DomainClasses.Company> query = _dbSet;

                if (request.Where != null)
                {
                    query = query.Where(request.Where);
                }

                return new Response
                {
                    Company = await query.Include(x => x.Document).OrderByDescending(x => x.Id).ToListAsync()
                };
            }
        }
    }
}
