using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Fantur.Core;
using Fantur.Core.Components;
using Fantur.Core.ViewModels;
using Java.Lang;

namespace Fantur.AndroidApp
{
    [Activity(Label = "Fantur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public class PlanetListViewAdapter : BaseAdapter<Entity>
        {
            private Activity context;
            private PlanetListView model;
            public override int Count => model.VisibleEntities().Count;
            public override Entity this[int position] => model.VisibleEntities()[position];

            public PlanetListViewAdapter(Activity context, PlanetListView model)
            {
                this.context = context;
                this.model = model;
                model.StateChange += (sender, args) => NotifyDataSetChanged();
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                var entity = this[position];
                var label = model.PlayerIsAt(entity)
                    ? $"* {entity.Name} - {entity.Orbit}"
                    : $"{entity.Name} - {entity.Orbit}";

                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = label;

                return view;
            }
        }

        public PlanetListView Model = new PlanetListView();
        private ListView _entityList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var playerOrbitEntry = FindViewById<EditText>(Resource.Id.playerOrbit);
            Model.StateChange += (sender, args) => playerOrbitEntry.Text = Model.PlayerOrbit.ToString();

            var goButton = FindViewById<Button>(Resource.Id.goButton);
            goButton.Click += (object sender, EventArgs e) =>
            {
                Model.PlayerOrbit = Convert.ToInt64(playerOrbitEntry.Text);
            };

            var listAdapter = new PlanetListViewAdapter(this, Model);

            _entityList = FindViewById<ListView>(Resource.Id.entities);
            _entityList.Adapter = listAdapter;
            _entityList.ItemClick += (sender, args) =>
            {
                var clickedEntity = Model.VisibleEntities()[args.Position];
                Model.MoveToEntity(clickedEntity);
            };
        }
    }
}
