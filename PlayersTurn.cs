using System;

namespace mis321_pa2_mdbrown17
{
    public class PlayersTurn
    {
        public static int Turn()
        {
            Random rnd = new Random();
            int num = rnd.Next(2);
            if(num == 0)
            {
                return 0;
            }
            else return 1;
        }
    }
}