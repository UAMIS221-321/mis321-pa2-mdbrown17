using mis321_pa2_mdbrown17.Interfaces;
using System;

namespace mis321_pa2_mdbrown17
{
    public class BuckShotBehavior : ISecondary
    {
        public int Secondary(Character myCharacter)
        {
            Random rnd = new Random();
            int hit = rnd.Next(3);
            
            if(hit == 1)
            {
                Console.WriteLine(myCharacter.name + "'s buckshot was effective!");
                return myCharacter.attackStrength * 2;
            }
            else
            {
                Console.WriteLine(myCharacter.name + "'s buckshot missed.");
                return 0;
            } 
        }
    }
}