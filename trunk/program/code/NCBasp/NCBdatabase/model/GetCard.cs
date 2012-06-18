using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace NCBdatabase.model
{
    class GetCard : connection
    {
        private ISessionFactory factory;

        public GetCard()
        {
        }

        public Card Get(int cardID)
        {
            this.factory = this.CreateSessionFactory("Player_CardMap");
            List<Card> listCard = new List<Card>();
            using (var session = this.factory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    listCard = session.Query<Card>()
                        .Where(u => u.CARD_ID.Equals(cardID))
                        .ToList();
                    tx.Commit();
                }
            }
            return listCard[0];
        }
    }
}
