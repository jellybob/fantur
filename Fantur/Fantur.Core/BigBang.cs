using Fantur.Core.Components;

namespace Fantur.Core
{
    // Creates the Universe at the start of a game.
    public class BigBang
    {
        public string[] PlanetNames = new[]
        {
            "Mercury",
            "Venus",
            "Earth",
            "Mars",
            "Jupiter",
            "Saturn",
            "Uranus",
            "Neptune",
            "Pluto", // Yup, I went there.
        };

        public Universe Universe;

        public static Universe CreateUniverse()
        {
            var bigBang = new BigBang();
            return bigBang.Explode();
        }

        public BigBang()
        {
            Universe = new Universe();
        }

        public Universe Explode()
        {
            CreatePlanets();

            return Universe;
        }

        private void CreatePlanets()
        {
            foreach (var name in PlanetNames)
            {
                var planet = new Entity();
                planet.AddComponent(new NamedEntity() { Name = name });
                Universe.AddEntity(planet);
            }
        }
    }
}