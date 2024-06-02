/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using System.Runtime.InteropServices;
using cardCode;
using Game;

namespace code{
    public class initGame
    {
        public IPlayer[] initiateEndTurn1(Battlefield battlefield){
            var ret = new IPlayer[2];
            IPlayer userA = new Wizard();
            IPlayer userB = new Wizard();
            userA.name = "Arold";
            userB.name = "Bryce";

            //in battlefield turn 1
            Land landcardA1T1= new Land();
            Land landcardA2T1= new Land();

            landcardA1T1.owner = userA;
            landcardA2T1.owner = userA;

            battlefield.lands.Add(landcardA1T1);
            battlefield.lands.Add(landcardA2T1);

            Land landcardB1T1= new Land();
            
            landcardB1T1.owner = userB;
            
            battlefield.lands.Add(landcardB1T1);
            
            //in hand turn 1 (afgeleid uit turn 2)
            Land landcardA3T2= new Land();
            userA.hand.Add(landcardA3T2);


            //dummy cards (unused in turn 2)
            // A 6 cards in hand 
            
            //(4 dummy)
            Land landcardA4T2= new Land();
            Land landcardA5T2= new Land();
            Land landcardA6T2= new Land();
            Land landcardA7T2= new Land();
            
            //(1 creature gespeeld in turn 2)
            Creature creaturecardA1T2= new Creature();
            creaturecardA1T2.baseAttack = 2;
            creaturecardA1T2.baseDefence = 2;
            creaturecardA1T2.cost = 2;
            creaturecardA1T2.owner = userA;
            creaturecardA1T2.colour = Colour.Blue;
            creaturecardA1T2.effect.description = "Opponent has to discard a random card from hand!!!";

            userA.hand.Add(landcardA4T2);
            userA.hand.Add(landcardA5T2);
            userA.hand.Add(landcardA6T2);
            userA.hand.Add(landcardA7T2);
            userA.hand.Add(creaturecardA1T2);

            // B 7 cards in hand
            Land landcardB2T2= new Land();
            Land landcardB3T2= new Land();
            Land landcardB4T2= new Land();
            Land landcardB5T2= new Land();
            Land landcardB6T2= new Land();
            Land landcardB7T2= new Land();
            Land landcardB8T2= new Land();

            userB.hand.Add(landcardB2T2);
            userB.hand.Add(landcardB3T2);
            userB.hand.Add(landcardB4T2);
            userB.hand.Add(landcardB5T2);
            userB.hand.Add(landcardB6T2);
            userB.hand.Add(landcardB7T2);
            userB.hand.Add(landcardB8T2);
/*
            User B:
            - 7 cards in hand
            - 1 land in battlefield
            - all lives

            User A:
            - 6 cards in hand
            - 2 lands on battlefield
            - all lives
*/

            // initiate random decks for userA & userB
            for(int i = 0; i < 30; i++){
                Random rnd = new Random();
                int number = rnd.Next(1, 4);
                if(number == 1){
                    userA.deck.Add(new Instantanious());
                    userB.deck.Add(new Instantanious());
                }
                else if (number == 2){
                    userA.deck.Add(new Creature());
                    userB.deck.Add(new Creature());
                }
                else if (number == 3){
                    userA.deck.Add(new Land());
                    userB.deck.Add(new Land());
                }
            }

            ret[0] = userA;
            ret[1] = userB;           
            return ret;
        }
    }
}