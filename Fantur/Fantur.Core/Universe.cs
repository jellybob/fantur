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
            Entities = new Dictionary<Guid, Entity>();
        }

        public void AddEntity(Entity entity)
        {
            entity.Universe = this;
            Entities.Add(entity.Guid, entity);
        }

        public Entity FindEntityByGuid(Guid guid)
        {
            return Entities[guid];
        }

        public List<Entity> FindAllEntitiesWithComponent(ComponentTypes component)
        {
            return Entities.Values.Where(entity => entity.HasComponent(component)).ToList();
        }

        public List<T> FindAllComponentsOfType<T>(ComponentTypes type)
        {
            return FindAllEntitiesWithComponent(type).Select(entity => entity.FindComponentByType(type)).OfType<T>().ToList();
        }

        public void Update()
        {
            // This is pretty hideous, but I know of no better way. It ensures that each component
            // type gets called in turn, rather than all over the place.
            //
            // I think in an ideal world you have systems which oversee a particular aspect of the
            // game, but I also think that's probably overkill here.
            var allComponents = new List<Component>();
            foreach (var entity in Entities.Values)
            {
                allComponents.AddRange(entity.Components.Values);
            }
            
            foreach (var componentGroup in allComponents.GroupBy(c => c.ComponentType))
            {
                foreach (var component in componentGroup)
                {
                    component.Update();
                }
            }
        }
    }
}
