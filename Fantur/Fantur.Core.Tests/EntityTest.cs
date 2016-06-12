using System;
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
    }
}
