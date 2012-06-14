using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace NCB.Mapping
{
    public sealed class TipeMap : ClassMap<Tipe>
    {
        public TipeMap()
        {
            Table("`tipe`");
            Id(x => x.TIPE_ID);
            Map(x => x.TIPE_NAME);
        }
    }
}
