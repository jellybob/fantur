using System;

namespace Fantur.Core
{
    [Flags]
    public enum ComponentTypes
    {
        Component,
        Name,
        UniverseTestTracker,
    }

    public class Component
    {
        public Guid Guid;
        public Entity Entity;
        public Universe Universe => Entity.Universe;
        public ComponentTypes ComponentType = 0;

        public Component() : this(Guid.NewGuid())
        {
        }

        public Component(Guid guid)
        {
            Guid = guid;
        }

        public virtual void Update()
        {
            
        }
    }
}