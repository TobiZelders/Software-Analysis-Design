/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
using System.Dynamic;
using System.Threading.Channels;
using Game;

namespace cardCode{
    //Component class
    public abstract class Card : ICard {
        public int id{ get; set; }
        public Effect effect { get; set; } = new Effect();
        public int cost { get; set; }
        public IPlayer owner { get; set; } = new Wizard();
        public Colour colour {get; set;}
        protected List<ICard> _components {get; set;} = new List<ICard>();
        public abstract void ShowEffect();

        public Card(){
            Random rnd = new Random();
            int number = rnd.Next(1, 1000);
            id = rnd.Next();
        }
        public void AddComponent(Card component) { _components.Add(component); }
        public void RemoveComponent(Card component) { _components.Remove(component); }
        
    }

    //Leaf class
    public class Land : Card {
        private int energy {get; set;}
        public Land(){ effect.description = "After 1 round in a battlefield you can turn the card to gain 1 energy. "; }
        public override void ShowEffect() { Console.WriteLine($"- {this} has the effect : {effect.description}"); }
    }

    //Composite class
    public class Spell : Card {
        private int attack {get; set;}
        private int defence {get; set;}
        public override void ShowEffect(){
            foreach(Card card in _components){ card.ShowEffect(); }}
    }

    //Leaf class
    public class Creature : Spell {
        public int baseDefence {get; set;} = 0;
        public int baseAttack {get; set;} = 0;
        public Creature() { effect.description = "Once placed in the battlefield it can defend you from attacks and attack targets for you. "; }
        public override void ShowEffect() { Console.WriteLine($"- {this} has the effect : {effect.description}"); }
    }

    //Leaf class
    public class Instantanious : Spell{
        public Instantanious(){ effect.description = "Once used it will instantly influence the game. "; }
        public override void ShowEffect() { Console.WriteLine($"- {this} has the effect : {effect.description}"); }
    }

    public enum Colour{
        Red,
        Blue,
        Green,
        Yellow,
        Purple,
        Orange
    }
}