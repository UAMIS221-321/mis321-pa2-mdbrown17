using mis321_pa2_mdbrown17.Interfaces;

namespace mis321_pa2_mdbrown17
{
    public class JackSparrow : Character
    {
        public JackSparrow()
        {
            attackBehavior = new DistractBehavior();
            secondaryBehavior = new PistolBehavior();
        }
    }
}