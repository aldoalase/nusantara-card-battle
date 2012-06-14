using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCB.Library;
using NCB.Mapping;
using NHibernate.Linq;
namespace NCB.Model
{
    class ModelTipe : DbConnection
    {
        public List<Tipe> loadTipe()
        {
            List<Tipe> listTipe = new List<Tipe>();
            var factory = this.CreateSessionFactory("TipeMap");
            using (var session = factory.OpenSession())
            {
                listTipe = session.Query<Tipe>()
                    .ToList();
            }
            return listTipe;
        }
    }
}
