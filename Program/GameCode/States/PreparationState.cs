/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PreparationState : IState
    {
        public PreparationState(Manager manager){ DoState(manager);}
        public void DoState(Manager manager)
        {
            System.Console.WriteLine("Preperation state is now running\n");
            ResetTemporaryEffects();
            ResetTurnedLands();
            EffectOfCardPreviousTurn();
            manager.currentState = new DrawingState(manager);
        }
        public void ResetTemporaryEffects(){}
        public void ResetTurnedLands(){}
        public void EffectOfCardPreviousTurn(){}
    }
}
