using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace lear.core.domain
{
    public interface IDBContext
    {
        public DbConnection  dbConnection { get; }
    }
}
