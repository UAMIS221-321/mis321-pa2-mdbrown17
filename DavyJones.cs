using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class DavyJones : Character
    {
        public DavyJones()
        {
            attackBehavior = new CannonFireBehavior();
            secondaryBehavior = new BuckShotBehavior();
        }
    }
}