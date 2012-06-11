using System.Collections.Generic; 
using System.Text; 
using System; 


namespace NCB {
    
    public class PlayerCard {
        public PlayerCard() { }
        public virtual int PlayerCardId { get; set; }
        public virtual Card Card { get; set; }
        public virtual Player Player { get; set; }
        public virtual System.Nullable<int> PlayerCardActive { get; set; }
    }
}
