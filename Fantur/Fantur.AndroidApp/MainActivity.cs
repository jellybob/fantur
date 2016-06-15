using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Fantur.Core;

namespace Fantur.AndroidApp
{
    [Activity(Label = "Fantur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        public Universe Universe;
        public Entity Player;
        protected string[] EntityNames;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Universe = BigBang.CreateUniverse();
            Player = Universe.FindAllEntitiesWithComponent(ComponentTypes.Player)[0];

            EntityNames = Universe.FindAllEntitiesWithComponent(ComponentTypes.Planet).Select(
                e => e.Orbit == Player.Orbit ? $"* {e.Name}" : $"{e.Name}"
            ).ToArray();

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, EntityNames);
        }
    }
}

