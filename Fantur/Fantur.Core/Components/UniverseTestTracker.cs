namespace Fantur.Core.Components
{
    public class UniverseTestTracker : Component
    {
        public bool Updated;

        public UniverseTestTracker() : base(ComponentTypes.UniverseTestTracker)
        {
        }

        public override void Update()
        {
            Updated = true;
        }
    }
}