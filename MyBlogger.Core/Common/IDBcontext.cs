using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MyBlogger.Core.Common
{
  public  interface IDBcontext
    {
        DbConnection Connection { get; }

    }
}
