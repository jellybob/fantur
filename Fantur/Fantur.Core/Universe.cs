using System;
using System.Collections.Generic;

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
            this.Entities.Add(entity.Guid, entity);
        }

        public Entity FindEntityByGuid(Guid guid)
        {
            return this.Entities[guid];
        }
    }
}
