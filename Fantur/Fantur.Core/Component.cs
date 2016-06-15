using System;

namespace Fantur.Core
{
    [Flags]
    public enum ComponentTypes
    {
        Component = 0,
        Name = 1,
        UniverseTestTracker = 2,
        Planet = 4,
        Player = 8,
        Location = 16,
    }

    public class Component
    {
        public Guid Guid;
        public Entity Entity;
        public Universe Universe => Entity.Universe;
        public ComponentTypes ComponentType = 0;

        public Component() : this(Guid.NewGuid(), ComponentTypes.Component)
        {
        }

        public Component(Guid guid) : this(guid, ComponentTypes.Component)
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