/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using cardCode;

namespace Game
{
    public class EndingState : IState
    {
        public EndingState(Manager manager) => DoState(manager);
        public void DoState(Manager manager){ 
            System.Console.WriteLine("Ending state now running\n");
            //Here all functions can be called upon by user input (cards should be discarded until player has 7 cards in hand)
            //this codeline should be called to invoke next state: manager.currentState = new PreparationState(manager);
            manager.waitingPlayersTurn();
        }
        public void DiscardCard(Card card, Manager manager){
            int index = manager.player.hand.IndexOf(card);
            manager.player.hand.RemoveAt(index);
            manager.player.discardPile.Add(card);
            System.Console.WriteLine($"{manager.player.name} has discarded a card ({card}) from his hand to discard pile");
        }
    }
}
