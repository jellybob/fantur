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

        public long[] PlanetPositions = new[]
        {
            57910000,
            108200000,
            149600000,
            227940000,
            778330000,
            1429400000,
            2870990000,
            4504300000,
            5913520000,
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
            CreatePlayer();

            return Universe;
        }

        private void CreatePlayer()
        {
            var player = new Entity();
            player.AddComponent(new NamedEntity("Player"));
            player.AddComponent(new Player());
            player.AddComponent(new Location(8942380));
            Universe.AddEntity(player);
        }

        private void CreatePlanets()
        {
            for (var i = 0; i < PlanetNames.Length; i++)
            {
                var planet = new Entity();
                planet.AddComponent(new NamedEntity(PlanetNames[i]));
                planet.AddComponent(new Planet());
                planet.AddComponent(new Location(PlanetPositions[i]));
                Universe.AddEntity(planet);
            }
        }
    }
}