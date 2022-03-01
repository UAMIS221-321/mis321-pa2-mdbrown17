using System;

namespace mis321_pa2_mdbrown17
{
    public class DefensePowerGenerator
    {
        public static int GetDefPower(int maxPwr) // returns a random num from 1 - max power
        {
            Random rnd = new Random();
            int maxStr = rnd.Next(1, maxPwr);
            return maxStr;
        }
    }
}