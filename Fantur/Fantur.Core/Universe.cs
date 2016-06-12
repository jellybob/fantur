using System;
using System.Collections.Generic;
using System.Linq;

namespace Fantur.Core
{
    public class Universe
    {
        public Dictionary<Guid, Entity> Entities;

        public Universe()
        {
            this.Entities = new Dictionary<Guid, Entity>();
        }

        public void AddEntity(Entity entity)
        {
            entity.Universe = this;
            this.Entities.Add(entity.Guid, entity);
        }

        public Entity FindEntityByGuid(Guid guid)
        {
            return this.Entities[guid];
        }

        public List<Entity> FindAllEntitiesWithComponent(ComponentTypes component)
        {
            return Entities.Values.Where(entity => entity.HasComponent(component)).ToList();
        }

        public List<T> FindAllComponentsOfType<T>(ComponentTypes type)
        {
            return FindAllEntitiesWithComponent(type).Select(entity => entity.FindComponentByType(type)).OfType<T>().ToList();
        }
    }
}
