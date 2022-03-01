using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class CannonFireBehavior : IAttack
    {
        public int Attack(Character myCharacter)
        {
            System.Console.WriteLine($" Boom! Boom! Boom!");
            
            return myCharacter.attackStrength;
        }
    }
}