using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class Character
    {
        public string name {get; set;}
        public int maxPower {get; set;}
        public double health {get; set;}
        public int attackStrength  {get; set;}
        public int defensePower {get; set;}
        public IAttack attackBehavior {get; set;}
        public ISecondary secondaryBehavior {get; set;}
        public Character()
        {
             
        }
    }
}