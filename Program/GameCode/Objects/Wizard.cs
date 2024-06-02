/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using System.Security.Cryptography.X509Certificates;
using cardCode;

namespace Game
{
    public class Wizard : IPlayer
    {
        public string? name { get; set; } = "";
        private int _life = 10;
        public int life { 
            get{return _life;} 
            set{_life = value;
                Notify();} }
        public int energyReservoir { get; set; } = 0;
        public List<IObserver> observers {get; set;} = new List<IObserver>();
        public List<Card> discardPile { get; set; } = new List<Card>();
        public List<Card> deck { get; set; } = new List<Card>();
        public List<Card> hand{get; set;} = new List<Card>();
        public void Attach(IObserver observer){observers.Add(observer);}
        public void Notify() { foreach(var o in observers) o.Update(this); }
    }

}
