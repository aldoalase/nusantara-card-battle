using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameAdmin.Mapping;

namespace GameAdmin
{
    public class Card
    {
        public virtual int CARD_ID { get; set; }
        public virtual string CARD_NAME { get; set; }
        public virtual string CARD_DESCRIPTION { get; set; }
        public virtual int CARD_STRENGTH { get; set; }
        public virtual int CARD_DEFENSE { get; set; }
        public virtual int CARD_HP { get; set; }
        public virtual int CARD_LEVEL { get; set; }
        public virtual Tipe Tipe { get; set; }
        public virtual int CARD_MAGIC_NUMBER { get; set; }
        public virtual int ENCHANT_STRENGTH { get; set; }
        public virtual int ENCHANT_DEFENSE { get; set; }
        public virtual int ENCHANT_HP { get; set; }
        public virtual double CARD_PRICE { get; set; }
        public override string ToString()
        {
            return CARD_NAME;
        }
    }
}
