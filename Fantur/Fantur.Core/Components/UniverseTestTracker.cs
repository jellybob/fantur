﻿namespace Fantur.Core.Components
{
    public class UniverseTestTracker : Component
    {
        public bool Updated;

        public UniverseTestTracker()
        {
            ComponentType = ComponentTypes.UniverseTestTracker;
        }

        public override void Update()
        {
            Updated = true;
        }
    }
}