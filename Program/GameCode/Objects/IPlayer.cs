/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using cardCode;

namespace Game
{
    public interface ISubject
    {
        public List<IObserver> observers {get; set;}
        public void Attach(IObserver observer);
        public void Notify();
    }

    public interface IPlayer : ISubject
    {
        string? name{ get; set; }
        int life { get; set;}
        int energyReservoir { get; set; }
        List<Card> discardPile { get; set; }
        List<Card> deck { get; set; }
        List<Card> hand { get; set; }
    }
}