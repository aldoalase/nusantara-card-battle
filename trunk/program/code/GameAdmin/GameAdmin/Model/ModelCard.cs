using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAdmin.Library;
using NHibernate.Linq;
using NHibernate;
namespace GameAdmin.Model
{
    class ModelCard : DbConnection
    {
        private ISessionFactory factory;
        public ModelCard()
        {
            this.factory = this.CreateSessionFactory("CardMap");
        }

        
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

        public bool Process(String process, Card current)
        {
            using (var session = this.factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    switch (process)
                    {
                        case "save":
                            session.Save(current);
                            break;
                        case "update":
                            session.Update(current);
                            break;
                        case "delete":
                            session.Delete(current);
                            break;
                    }
                    transaction.Commit();
                }
            }
            return true;
        }
    }
}
