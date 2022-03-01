using System;

namespace mis321_pa2_mdbrown17
{
    public class AttackStrengthGenerator
    {
        public static int GetAttackStr(int maxPwr) // returns a random num from 1 - max power
        {
            Random rnd = new Random();
            int attackStr = rnd.Next(1, maxPwr);
            return attackStr;
        }
    }
}