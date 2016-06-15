namespace Fantur.Core.Components
{
    public class Location : Component
    {
        public long CurrentOrbit;

        public Location(long currentOrbit) : base(ComponentTypes.Location)
        {
            CurrentOrbit = currentOrbit;
        }
    }
}