using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class WillTurner : Character
    {
        public WillTurner()
        {
            attackBehavior = new SwordBehavior();
            secondaryBehavior = new KickBehavior();
        }
    }
}