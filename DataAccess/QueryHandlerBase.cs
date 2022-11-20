using Yara.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public abstract class QueryHandlerBase
    {
        private readonly YaraContext _db;
        public QueryHandlerBase(YaraContext db)
        {
            _db = db;
        }
    }
}
