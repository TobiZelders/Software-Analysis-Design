/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using Game;

namespace cardCode{
    public interface ICard
    {
        int id{ get; set; }
        Effect effect { get; set; }
        int cost { get; set; }
        IPlayer owner { get; set; }
    }
}