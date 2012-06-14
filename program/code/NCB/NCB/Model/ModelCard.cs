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

        public List<Card> getTipeCard(int typeId)
        {
            List<Card> listCard = new List<Card>();
            var factory = this.CreateSessionFactory("CardMap");
            using (var session = factory.OpenSession())
            {
                listCard = session.Query<Card>()
                    .Where(c => c.Tipe.TIPE_ID == typeId)
                    .ToList();
            }
            return listCard;
        }

        public Card getCard(int id)
        {
            List<Card> kartu = new List<Card>();
            var factory = this.CreateSessionFactory("CardMap");
            using (var session = factory.OpenSession())
            {
                kartu = session.Query<Card>()
                    .Where(u => u.CARD_ID.Equals(id))
                    .ToList();
            }
            return kartu[0];
        }
    }
}
