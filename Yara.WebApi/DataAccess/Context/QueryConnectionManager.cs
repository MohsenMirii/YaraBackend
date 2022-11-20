using Yara.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public abstract class QueryConnectionManager
    {
        public readonly YaraContext _db;
        public QueryConnectionManager(YaraContext db)
        {
            _db = db;
        }
    }
}
