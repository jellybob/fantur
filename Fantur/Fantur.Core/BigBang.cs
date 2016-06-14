using System.Collections.Generic;
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

        public List<Entity> Planets;
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
            CreatePlayer();

            return Universe;
        }

        private void CreatePlayer()
        {
            var player = new Entity();
            player.AddComponent(new NamedEntity() { Name = "Player" });
            player.AddComponent(new Player());

            var playerLocation = new Location(Planets[2]); // Start on Earth.
            player.AddComponent(playerLocation);
            Universe.AddEntity(player);
        }

        private void CreatePlanets()
        {
            Planets = new List<Entity>();
            foreach (var name in PlanetNames)
            {
                var planet = new Entity();
                planet.AddComponent(new NamedEntity() { Name = name });
                planet.AddComponent(new Planet());
                Universe.AddEntity(planet);
                Planets.Add(planet);
            }
        }
    }
}