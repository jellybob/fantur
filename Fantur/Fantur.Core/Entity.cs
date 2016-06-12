using System;
using System.Collections.Generic;

namespace Fantur.Core
{
    public class Entity
    {
        public Guid Guid;
        public Dictionary<Guid, Component> Components;

        public Entity()
        {
            Initialize(Guid.NewGuid());
        }

        public Entity(Guid guid)
        {
            Initialize(guid);
        }

        public void AddComponent(Component component)
        {
            Components.Add(component.Guid, component);
        }

        public Component FindComponentByGuid(Guid guid)
        {
            return Components[guid];
        }

        private void Initialize(Guid guid)
        {
            Guid = guid;
            Components = new Dictionary<Guid, Component>();
        }
    }
}