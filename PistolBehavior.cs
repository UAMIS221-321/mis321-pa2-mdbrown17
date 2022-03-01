using mis321_pa2_mdbrown17.Interfaces;
using System;

namespace mis321_pa2_mdbrown17
{
    public class PistolBehavior : ISecondary
    {
        public int Secondary(Character myCharacter)
        {
            Random rnd = new Random();
            int hit = rnd.Next(10);
            
            if(hit == 1)
            {
                Console.WriteLine(myCharacter.name + "'s pistol shot was effective!");
                return myCharacter.attackStrength * 100;
            }
            else
            {
                Console.WriteLine(myCharacter.name + "'s pistol shot missed.");
                return 0;
            } 
        }
    }
}