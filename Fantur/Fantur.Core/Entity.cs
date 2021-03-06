﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fantur.Core.Components;

namespace Fantur.Core
{
    public class Entity
    {
        public Guid Guid;
        public Dictionary<ComponentTypes, Component> Components;
        public Universe Universe;
        public ComponentTypes IncludedComponents;

        public string Name
        {
            get
            {
                var nameEntity = (NamedEntity) FindComponentByType(ComponentTypes.Name);
                return nameEntity.Name;
            }
            set
            {
                var nameEntity = (NamedEntity) FindComponentByType(ComponentTypes.Name);
                nameEntity.Name = value;
            }
        }

        public long Orbit
        {
            get
            {
                var location = (Location) FindComponentByType(ComponentTypes.Location);
                return location.CurrentOrbit;
            }
            set
            {
                var location = (Location) FindComponentByType(ComponentTypes.Location);
                location.CurrentOrbit = value;
            }
        }

        public Entity() : this(Guid.NewGuid())
        {
        }

        public Entity(Guid guid)
        {
            Guid = guid;
            Components = new Dictionary<ComponentTypes, Component>();
        }
        
        public void AddComponent(Component component)
        {
            component.Entity = this;
            IncludedComponents = IncludedComponents | component.ComponentType;
            Components.Add(component.ComponentType, component);
        }

        public Component FindComponentByGuid(Guid guid)
        {
            return Components.Values.FirstOrDefault(c => c.Guid == guid);
        }

        public Component FindComponentByType(ComponentTypes type)
        {
            return Components[type];
        }

        public bool HasComponent(ComponentTypes type)
        {
            return IncludedComponents.HasFlag(type);
        }
    }
}