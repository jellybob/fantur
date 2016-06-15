using System;
using Fantur.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fantur.Core.Tests
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TestEntityIsAssignedAGuidIfNotPresent()
        {
            var entity = new Entity();

            Assert.AreNotEqual(Guid.Empty, entity.Guid);
        }

        [TestMethod]
        public void TestEntityUsesAssignedGuidIfPresent()
        {
            var assignedGuid = Guid.NewGuid();
            var entity = new Entity(assignedGuid);

            Assert.IsNotNull(entity.Guid);
            Assert.AreEqual(assignedGuid, entity.Guid);
        }

        [TestMethod]
        public void TestEntityCanHaveManyComponents()
        {
            var entity = new Entity();
            var component = new Component();

            entity.AddComponent(component);
            Assert.AreNotEqual(0, entity.Components.Count);
        }

        [TestMethod]
        public void TestEntityComponentsCanBeFoundByGuid()
        {
            var guid = Guid.NewGuid();
            var entity = new Entity();
            var component = new Component(guid);
            entity.AddComponent(component);

            Assert.AreSame(component, entity.FindComponentByGuid(guid));
        }

        [TestMethod]
        public void TestAddingAComponentToAnEntitySetsAReference()
        {
            var entity = new Entity();
            var component = new Component();
            entity.AddComponent(component);

            Assert.AreSame(entity, component.Entity);
        }

        [TestMethod]
        public void TestComponentsCanBeFoundByType()
        {
            var entity = new Entity();
            var nameComponent = new NamedEntity("Test Entity");
            entity.AddComponent(nameComponent);

            var foundComponent = entity.FindComponentByType(ComponentTypes.Name);
            Assert.AreSame(nameComponent, foundComponent);
        }

        [TestMethod]
        public void TestEntitiesKnowWhatComponentsTheyContain()
        {
            var entity = new Entity();
            var nameComponent = new NamedEntity("Test Entity");
            entity.AddComponent(nameComponent);

            Assert.IsTrue(entity.HasComponent(ComponentTypes.Name));
        }
    }
}
