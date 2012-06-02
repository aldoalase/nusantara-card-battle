using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NCB;

namespace NCB
{
    class DbConnection
    {
        public MySQLConfiguration config()
        {
            return MySQLConfiguration.Standard.ConnectionString(c => c.Server("10.151.36.38")
                    .Database("tcgn")
                    .Username("tcgn")
                    .Password("tcgn"));
        }
    }
}
