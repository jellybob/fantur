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

            Entity.AddComponent(new NamedEntity("Name"));

            var foundEntities = Universe.FindAllEntitiesWithComponent(ComponentTypes.Name);
            Assert.AreEqual(1, foundEntities.Count);
            Assert.AreSame(Entity, foundEntities[0]);
        }

        [TestMethod]
        public void TestUniverseCanFindAllComponentsOfAType()
        {
            var firstName = new NamedEntity("First Name");
            Entity.AddComponent(firstName);

            var extraEntity = new Entity();
            var extraName = new NamedEntity("Extra Name");
            extraEntity.AddComponent(extraName);
            Universe.AddEntity(extraEntity);

            var otherComponent = new Component();
            extraEntity.AddComponent(otherComponent);

            var foundComponents =
                Universe.FindAllComponentsOfType<NamedEntity>(ComponentTypes.Name);
            Assert.AreEqual(2, foundComponents.Count);
        }

        [TestMethod]
        public void TestUniverseCallsUpdateForEveryComponentEachTick()
        {
            var testTracker1 = new UniverseTestTracker();
            Entity.AddComponent(testTracker1);

            var secondEntity = new Entity();
            var testTracker2 = new UniverseTestTracker();
            secondEntity.AddComponent(testTracker2);
            Universe.AddEntity(secondEntity);

            Universe.Update();

            Assert.IsTrue(testTracker1.Updated);
            Assert.IsTrue(testTracker2.Updated);
        }
    }
}
