/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using cardCode;

namespace Game
{
    public class DrawingState : IState
    {
        public DrawingState(Manager manager) => DoState(manager);
        public void DoState(Manager manager) {
            System.Console.WriteLine("Drawing state is now running\n");
            if(manager.player.deck.Count == 0) manager.currentState = new GameOver(manager);
            else if(manager.player.hand.IndexOf(manager.player.hand.Last()) < 6) 
                DrawCard(manager);
            //uncomment to change state automatically after drawing 1 card by on turn player: manager.currentState = new MainState(manager);
        }
        public void DrawCard(Manager manager){
            Card drawnCard = manager.player.deck.First();
            manager.player.deck.RemoveAt(0);
            manager.player.hand.Add(drawnCard);
            System.Console.WriteLine($"{manager.player.name} has drawn a card from deck ({drawnCard})");
        }
    }
}
