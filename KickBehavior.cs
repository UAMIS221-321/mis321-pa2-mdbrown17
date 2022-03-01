using mis321_pa2_mdbrown17.Interfaces;
using System;

namespace mis321_pa2_mdbrown17
{
    public class KickBehavior : ISecondary
    {
        public int Secondary(Character myCharacter)
        {
            Random rnd = new Random();
            int hit = rnd.Next(5);
            
            if(hit == 1)
            {
                Console.WriteLine(myCharacter.name + "'s kick was effective!");
                return myCharacter.attackStrength * 3;
            }
            else
            {
                Console.WriteLine(myCharacter.name + "'s kick missed.");
                return 0;
            } 
        }
    }
}