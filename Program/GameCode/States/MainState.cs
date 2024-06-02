/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using cardCode;

namespace Game
{
    public class MainState : IState
    {
        public MainState(Manager manager) => DoState(manager);
        public void DoState(Manager manager){
            System.Console.WriteLine("Main state is now running\n");
            //Here all functions can be called upon by user input
            //this codeline should be called to invoke next state: manager.currentState = new EndingState(manager);
        }
        public void CallInterrupt(){}
        public void Play(Card card, Battlefield battlefield, Manager manager){

            if(card.GetType() == typeof(Land) ){
                int index = manager.player.hand.IndexOf(card);
                manager.player.hand.RemoveAt(index);
                battlefield.lands.Add(card); 
                System.Console.WriteLine($"{manager.player.name} plays card ({card}) from hand\nThat Card ({card}) is now on battlefield");
            
            }
            else if(card.GetType() == typeof(Creature) && manager.player.energyReservoir >= card.cost ){
                int index = manager.player.hand.IndexOf(card);
                manager.player.hand.RemoveAt(index);
                battlefield.creatures.Add(card); 
                System.Console.WriteLine($"{manager.player.name} plays card ({card})\nThat card ({card}) is now on battlefield\nThe Creatures effect is {card.effect.description}");
                manager.player.energyReservoir -= card.cost;
            }
            
            else if(card.GetType() == typeof(Instantanious) && manager.player.energyReservoir >= card.cost  ){
                int index = manager.player.hand.IndexOf(card);
                manager.player.hand.RemoveAt(index);  
                battlefield.instantanious.Add(card);
                System.Console.WriteLine($"{manager.player.name} plays card ({card})\nThat card ({card}) is now on battlefield");
                manager.player.energyReservoir -= card.cost;
            }

            else System.Console.WriteLine("Invalid card chosen to play!");
        }

        public void TurnLand(Card card, Battlefield battlefield, Manager manager)
        {
            try {
                int index = battlefield.lands.IndexOf(card);
                battlefield.lands.RemoveAt(index);
                battlefield.turnedLands.Add(card);
                Console.WriteLine($"{manager.player.name} turned 1 land card");
                battlefield.AddEnergy(manager.player);
                }
            catch{Console.WriteLine("This card is not turnable");}
        }

        public void DiscardCard(Card card, Manager manager){
            int index = manager.player.hand.IndexOf(card);
            manager.player.hand.RemoveAt(index);
            manager.player.discardPile.Add(card);
            System.Console.WriteLine($"{manager.player.name} has discarded a card ({card}) from his hand to discard pile");
        }
        public void DoDamage(Card attacker, string target){}
    }
}
