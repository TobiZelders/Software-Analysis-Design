/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using System.Reflection.Metadata;
using cardCode;
using Game;
using Microsoft.VisualBasic;

namespace code;

class Program
{
    static void Main(string[] args)
    {
        Battlefield battlefield = Battlefield.GetInstance();
        Manager manager = Manager.GetInstance();

        var game = new initGame();
        IPlayer[] players = game.initiateEndTurn1(battlefield);

        IPlayer userA = players[0];
        IPlayer userB = players[1];
        
        System.Console.WriteLine("Turn 1 was hardcoded and is now identical to the assignment scenario!\n ");

        Console.WriteLine("Turn 2 - SD about to be played out...\n\n");

        //Preperation state        
        manager.player = userA;
        manager.waitingPlayer = userB;
        
        //Drawing state
        manager.InitializeGame();
            // User A draws card

        //Main state
        MainState MainS = new MainState(manager);
            //A Plays Land card
        MainS.Play(manager.player.hand.First(),battlefield, manager);

            //A turns 2 cards, gets 2 energy
        MainS.TurnLand(battlefield.lands.First(), battlefield, manager);
        MainS.TurnLand(battlefield.lands.First(), battlefield, manager);
            
            //A plays permanent card
        MainS.Play(manager.player.hand.ElementAt(4), battlefield, manager);

            //User B Discards random card (effect of permanent card Player A)
        Random rnd = new Random();
        int number = rnd.Next(0,6);
        manager.waitingPlayersTurn();
        MainS.DiscardCard(manager.player.hand.ElementAt(number), manager);
        manager.waitingPlayersTurn();
        
        //Ending state
        EndingState endingS = new EndingState(manager);
        
        //Preperation state
        PreparationState preparationS = new PreparationState(manager);
        
        //Drawing state (all automatic)
            //Player B draws a card

        //Main state
        MainS = new MainState(manager);
        
        //Ending state
        endingS = new EndingState(manager);
    }
} 