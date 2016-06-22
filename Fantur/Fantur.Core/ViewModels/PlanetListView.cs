using System;
using System.Collections.Generic;
using System.Linq;

namespace Fantur.Core.ViewModels
{
    public class PlanetListView
    {
        public Game Game;
        public Entity Player;
        public List<Entity> Planets;
        public event EventHandler StateChange;

        public long PlayerOrbit
        {
            get { return Player.Orbit; }
            set { Player.Orbit = value; OnStateChange(); }
        }

        public PlanetListView()
        {
            this.Game = new Game();
            this.Player = Game.Player;
            this.Planets = Game.Planets;
        }

        public List<Entity> VisibleEntities()
        {
            var playerPlanet = Game.Planets.FirstOrDefault(e => e.Orbit == Game.Player.Orbit);
            var visibleEntities = new List<Entity>();
            visibleEntities.AddRange(Game.Planets);
            if (playerPlanet == null)
            {
                visibleEntities.Add(Game.Player);
            }

            return visibleEntities.OrderBy(e => e.Orbit).ToList();
        }

        public bool PlayerIsAt(Entity location)
        {
            return location != Player && location.Orbit == Player.Orbit;
        }

        public void MoveToEntity(Entity target)
        {
            PlayerOrbit = target.Orbit;
        }

        protected virtual void OnStateChange()
        {
            StateChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
