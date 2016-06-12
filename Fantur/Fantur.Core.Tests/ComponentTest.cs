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
    }
}
