using System.Collections.Generic;

namespace Fantur.Core
{
    public class Game
    {
        public Universe Universe;
        public Entity Player;
        public List<Entity> Planets;

        public Game()
        {
            Universe = BigBang.CreateUniverse();
            Player = Universe.FindAllEntitiesWithComponent(ComponentTypes.Player)[0];
            Planets = Universe.FindAllEntitiesWithComponent(ComponentTypes.Planet);
        }
    }
}