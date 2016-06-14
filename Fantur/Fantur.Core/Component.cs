using System;

namespace Fantur.Core
{
    [Flags]
    public enum ComponentTypes
    {
        Component,
        Name,
        UniverseTestTracker,
        Planet,
        Player,
        Location,
    }

    public class Component
    {
        public Guid Guid;
        public Entity Entity;
        public Universe Universe => Entity.Universe;
        public ComponentTypes ComponentType = 0;

        public Component() : this(ComponentTypes.Component)
        {
        }

        public Component(ComponentTypes componentType) : this(Guid.NewGuid(), componentType)
        {
        }

        public Component(Guid guid, ComponentTypes componentType)
        {
            Guid = guid;
            ComponentType = componentType;
        }

        public virtual void Update()
        {
            
        }
    }
}