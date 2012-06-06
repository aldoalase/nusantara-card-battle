using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCB.Library;
using NHibernate.Linq;
namespace NCB.Model
{
    class ModelCard : DbConnection
    {
        public List<Card> loadCards()
        {
            List<Card> listCard = new List<Card>();
            var factory = this.CreateSessionFactory("CardMap");
            using (var session = factory.OpenSession())
            {
                listCard = session.Query<Card>()
                    .ToList();
            }
            return listCard;
        }
    }
}
