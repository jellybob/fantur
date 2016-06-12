using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fantur.Core.Tests
{
    [TestClass]
    public class UniverseTest
    {
        [TestMethod]
        public void TestBigBang()
        {
            var u = new Universe();
            Assert.IsNotNull(u);
        }

        [TestMethod]
        public void TestUniverseCanContainManyEntities()
        {
            var universe = new Universe();
            var entity = new Entity();

            universe.AddEntity(entity);

            Assert.AreNotEqual(0, universe.Entities.Count);
        }

        [TestMethod]
        public void TestUniverseCanLookupEntityByGuid()
        {
            var universe = new Universe();
            var entity = new Entity();

            universe.AddEntity(entity);

            Assert.AreSame(entity, universe.FindEntityByGuid(entity.Guid));
        }
    }
}
