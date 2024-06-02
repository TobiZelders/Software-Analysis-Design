/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
namespace Game{
    public class GameOver : IState{
                public void DoState(Manager manager){/*all functionality to end the game*/}
                public GameOver(Manager manager){ DoState(manager);}
    }

        public class Empty : IState{
            public void DoState(Manager manager){}
            public Empty(Manager manager){ DoState(manager);}
        }
}