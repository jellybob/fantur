using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Fantur.Core;
using Fantur.Core.ViewModels;

namespace Fantur.AndroidApp
{
    [Activity(Label = "Fantur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public class PlanetListViewAdapter : BaseAdapter<Entity>
        {
            protected readonly Activity Context;
            protected readonly PlanetListView Model;
            public override int Count => Model.VisibleEntities().Count;
            public override Entity this[int position] => Model.VisibleEntities()[position];

            public PlanetListViewAdapter(Activity context, PlanetListView model)
            {
                this.Context = context;
                this.Model = model;
                model.StateChange += (sender, args) => NotifyDataSetChanged();
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = convertView ?? Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                var entity = this[position];
                var label = Model.PlayerIsAt(entity)
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
