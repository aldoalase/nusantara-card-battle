using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAdmin.Library;
using GameAdmin.Mapping;
using NHibernate.Linq;
namespace GameAdmin.Model
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
