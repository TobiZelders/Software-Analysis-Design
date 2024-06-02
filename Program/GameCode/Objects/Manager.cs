/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
namespace Game
{
    public class Manager : IObserver
    {
        private static Manager manager = new Manager();
        private IPlayer winner{ get; set;} = new Wizard();
        public IState currentState{ get; set;} = new Empty(manager);
        public IPlayer player { get; set; } = new Wizard();
        public IPlayer waitingPlayer { get; set; } = new Wizard();
        private Manager(){}
        public static Manager GetInstance() => manager;
        public void InitializeGame() { currentState = new PreparationState(this); }
        public void waitingPlayersTurn(){
            var NEWwaitingPlayer = player;
            player = waitingPlayer;
            waitingPlayer = NEWwaitingPlayer;
        }
        public void Update(ISubject subject){
            IPlayer? player = subject as IPlayer;
            if(player != null)
            {
                System.Console.WriteLine($"Observer got updated\n{player.name} has: {player.life} lives");
                
                if(player.life<=0)
                {
                    winner = waitingPlayer;
                    System.Console.WriteLine($"{player.name} has died\n\n\n{winner.name} HAS WON THE GAME!!!!!");
                    currentState = new GameOver(this);
                }
            }
        }
    }

    public interface IObserver{
        public void Update(ISubject subject);
    }

        public interface IState
    {
        public void DoState(Manager manager) {  }
    }
}
