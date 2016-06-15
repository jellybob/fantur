using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Fantur.Core;
using Fantur.Core.Components;
using Java.Lang;

namespace Fantur.AndroidApp
{
    [Activity(Label = "Fantur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public Game Game = new Game();
        private ListView _entityList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var playerOrbitEntry = FindViewById<EditText>(Resource.Id.playerOrbit);
            playerOrbitEntry.Text = Game.Player.Orbit.ToString();
            var goButton = FindViewById<Button>(Resource.Id.goButton);
            goButton.Click += (object sender, EventArgs e) =>
            {
                SetPlayerPosition(Convert.ToInt64(playerOrbitEntry.Text));
            };


            _entityList = FindViewById<ListView>(Resource.Id.entities);
            _entityList.Adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleListItem1
            );
            UpdateEntityLabels();
        }

        protected void SetPlayerPosition(long position)
        {
            Game.Player.Orbit = position;
            UpdateEntityLabels();
        }

        protected void UpdateEntityLabels()
        {
            var adapter = (ArrayAdapter)_entityList.Adapter;
            adapter.Clear();
            adapter.AddAll(EntityLabels());
            adapter.NotifyDataSetChanged();
        }

        protected List<string> EntityLabels()
        {
            var playerPlanet = Game.Planets.FirstOrDefault(e => e.Orbit == Game.Player.Orbit);
            var visibleEntities = new List<Entity>();
            visibleEntities.AddRange(Game.Planets);
            if (playerPlanet == null)
            {
                visibleEntities.Add(Game.Player);
            }

            return visibleEntities.OrderBy(e => e.Orbit)
                    .Select(
                        e =>
                            e.Orbit == Game.Player.Orbit && e != Game.Player
                                ? $"* {e.Name} - {e.Orbit}"
                                : $"{e.Name} - {e.Orbit}")
                    .ToList<string>();
        }
    }
}

