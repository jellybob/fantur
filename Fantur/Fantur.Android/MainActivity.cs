using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Fantur.Core;

namespace Fantur.AndroidApp
{
    [Activity(Label = "Fantur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        protected Universe Universe;
        private string[] items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Universe = BigBang.CreateUniverse();
            items = Universe.FindAllEntitiesWithComponent(ComponentTypes.Name).Select(e => e.Name).ToArray();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}

