using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fantur.Core.Tests
{
    [TestClass]
    public class ComponentTest
    {
        [TestMethod]
        public void CreationAssignsAGuidIfNotPresent()
        {
            var component = new Component();

            Assert.AreNotEqual(Guid.Empty, component.Guid);
        }

        [TestMethod]
        public void CreationUsesProvidedGuidIfPresent()
        {
            var expectedGuid = Guid.NewGuid();
            var component = new Component(expectedGuid);

            Assert.AreEqual(expectedGuid, component.Guid);
        }

        [TestMethod]
        public void AllowsAccessToTheWiderUniverse()
        {
            var universe = new Universe();
            var entity = new Entity {Universe = universe};
            var component = new Component {Entity = entity};

            Assert.AreSame(universe, component.Universe);
        }
    }
}
