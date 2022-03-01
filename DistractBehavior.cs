using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class DistractBehavior : IAttack
    {
        public int Attack(Character myCharacter)
        {
            System.Console.WriteLine(myCharacter.name + " : ''Look over there!'' ");
            return myCharacter.attackStrength;
        }
    }
}