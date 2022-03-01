using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class SwordBehavior : IAttack
    {
        public int Attack(Character myCharacter)
        {
            System.Console.WriteLine($" Slash!!!");
            return myCharacter.attackStrength;
        }
    }
}