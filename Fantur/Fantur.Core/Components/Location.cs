namespace Fantur.Core.Components
{
    public class Location : Component
    {
        public Entity CurrentLocation;

        public Location(Entity currentLocation) : base(ComponentTypes.Location)
        {
            CurrentLocation = currentLocation;
        }
    }
}