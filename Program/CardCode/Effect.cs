/*
Daniel Jong 0997226
Tobias Zelders 0981403
*/
namespace cardCode
{
    public class Effect{
        public string description {get; set;} = "";
        private int duration {get; set;}
        private string target {get; set;} = "";
        private bool playableInOppsTurn {get; set;}
    }
}