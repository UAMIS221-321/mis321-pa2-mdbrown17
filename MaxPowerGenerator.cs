using System;

namespace mis321_pa2_mdbrown17
{
    public class MaxPowerGenerator
    {
        public static int GetMaxPwr() // returns a random num from 1 - 100
        {
            Random rnd = new Random();
            int maxPwr = rnd.Next(1, 100);
            return maxPwr;
        }
    }
}