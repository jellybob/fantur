﻿using System.Collections.Generic;
using System.Linq;
using Fantur.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fantur.Core.Tests
{
    [TestClass]
    public class UniverseTest
    {
        public Universe Universe;
        public Entity Entity;

        [TestInitialize]
        public void SetUp()
        {
            Universe = new Universe();
            Entity = new Entity();
            Universe.AddEntity(Entity);
        }

        [TestMethod]
        public void TestUniverseCanContainManyEntities()
        {
            Assert.AreEqual(1, Universe.Entities.Count);
        }

        [TestMethod]
        public void TestUniverseCanLookupEntityByGuid()
        {
            Assert.AreSame(Entity, Universe.FindEntityByGuid(Entity.Guid));
        }

        [TestMethod]
        public void TestAddingAnEntityToTheUniverseSetsAReference()
        {
            Assert.AreSame(Universe, Entity.Universe);
        }

        [TestMethod]
        public void TestUniverseCanFindAllEntitiesIncludingAComponent()
        {
            var unexpectedEntity = new Entity();
            Universe.AddEntity(unexpectedEntity);

            Entity.AddComponent(new NamedEntity());

            var foundEntities = Universe.FindAllEntitiesWithComponent(ComponentTypes.Name);
            Assert.AreEqual(1, foundEntities.Count);
            Assert.AreSame(Entity, foundEntities[0]);
        }

        [TestMethod]
        public void TestUniverseCanFindAllComponentsOfAType()
        {
            var firstName = new NamedEntity();
            Entity.AddComponent(firstName);

            var extraEntity = new Entity();
            var extraName = new NamedEntity();
            extraEntity.AddComponent(extraName);
            Universe.AddEntity(extraEntity);

            var otherComponent = new Component();
            extraEntity.AddComponent(otherComponent);

            var foundComponents =
                Universe.FindAllComponentsOfType<NamedEntity>(ComponentTypes.Name);
            Assert.AreEqual(2, foundComponents.Count);
        }
    }
}
