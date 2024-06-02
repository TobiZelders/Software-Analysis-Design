/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using cardCode;

namespace Game
{
    public class Battlefield{
        private static Battlefield battlefield = new Battlefield();
        public List<Card> lands {get; set;} = new List<Card>();
        public List<Card> turnedLands {get; set;} = new List<Card>();
        public List<Card> instantanious {get; set;} = new List<Card>();
        public List<Card> creatures {get; set;} = new List<Card>();
        private Battlefield(){ }
        public static Battlefield GetInstance() => battlefield;
        public void IsTargetExisting(Card card){} 
        public void AddEnergy(IPlayer player) {player.energyReservoir++; System.Console.WriteLine($"{player.name}'s energy has increased by: 1 ");}
    }
}