﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System.Diagnostics;

namespace WeathApp.Droid
{
    [Activity(Label = "Xamarin Projects", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]

    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        private Button btnNormal;
        private Button btnHybrid;
        private Button btnSatellite;
        private Button btnTerrain;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Home);


            Button button = FindViewById<Button>(Resource.Id.weatherButton);
            button.Click += Button3_Click;

            Button button2 = FindViewById<Button>(Resource.Id.toDoButton);
            button2.Click += Button4_Click;

            Button button3 = FindViewById<Button>(Resource.Id.mapButton);
            button3.Click += Button6_Click;

            Button button4 = FindViewById<Button>(Resource.Id.mileageButton);
            button4.Click += Button7_Click;
        }

        private void SetUpMap()
        {
            if(mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            System.Diagnostics.Debug.Print("****###" + mMap.MaxZoomLevel);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.ToDo);

            Button button2 = FindViewById<Button>(Resource.Id.TaskBtn);
            button2.Click += Button5_Click;

            Button button3 = FindViewById<Button>(Resource.Id.HomeButton);
            button3.Click += Button2_Click;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            EditText TaskEntry = FindViewById<EditText>(Resource.Id.TaskEntry);

            Button button2 = FindViewById<Button>(Resource.Id.HomeButton);
            button2.Click += Button2_Click;

            if (!String.IsNullOrEmpty(TaskEntry.Text))
            {
                string entry = TaskEntry.Text;
                Item newItem = new Item();
                newItem.Description = entry;
                var allItems = Item.GetAll();
                var list = "";
                foreach(var item in allItems)
                    {
                    list += item.Description + "\n";
                    }
                FindViewById<TextView>(Resource.Id.TaskListTexts).Text = list;
            }
        }
        private async void Button_Click(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.ZipCodeEntry);
            Button button2 = FindViewById<Button>(Resource.Id.HomeButton);
            button2.Click += Button2_Click;

            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Map);

            SetUpMap();

            btnNormal = FindViewById<Button>(Resource.Id.btnNormal);
            btnHybrid = FindViewById<Button>(Resource.Id.btnHybrid);
            btnSatellite = FindViewById<Button>(Resource.Id.btnSatellite);
            btnTerrain = FindViewById<Button>(Resource.Id.btnTerrain);

            btnNormal.Click += btnNormal_Click;
            btnHybrid.Click += btnHybrid_Click;
            btnSatellite.Click += btnSatellite_Click;
            btnTerrain.Click += btnTerrain_Click;

            Button button2 = FindViewById<Button>(Resource.Id.HomeButton);
            button2.Click += Button2_Click;
        }

        void btnNormal_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeNormal;
        }

        void btnHybrid_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeHybrid;
        }

        void btnSatellite_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeSatellite;
        }

        void btnTerrain_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeTerrain;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Home);

            Button button = FindViewById<Button>(Resource.Id.weatherButton);
            button.Click += Button3_Click;

            Button button2 = FindViewById<Button>(Resource.Id.toDoButton);
            button2.Click += Button4_Click;

            Button button3 = FindViewById<Button>(Resource.Id.mapButton);
            button3.Click += Button6_Click;


            Button button4 = FindViewById<Button>(Resource.Id.mileageButton);
            button4.Click += Button7_Click;


            Recreate();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);
            button.Click += Button_Click;

            Button button2 = FindViewById<Button>(Resource.Id.HomeButton);
            button2.Click += Button2_Click;

        }



        private void Button7_Click(object sender, EventArgs e)
        {
          SetContentView(Resource.Layout.Mileage);

          Button button3 = FindViewById<Button>(Resource.Id.HomeButton);
          button3.Click += Button2_Click;

          Button button8 = FindViewById<Button>(Resource.Id.MileageBtn);
          button8.Click += Button8_Click;
        }

        private void Button8_Click(object sender, EventArgs e)
        {

          EditText milesDriven = FindViewById<EditText>(Resource.Id.MilesInput);
          EditText gallonsFuel = FindViewById<EditText>(Resource.Id.GallonsInput);

          if ((!String.IsNullOrEmpty(milesDriven.Text)) && (!String.IsNullOrEmpty(gallonsFuel.Text)))
          {
            float inputMiles = Int32.Parse(milesDriven.Text);
            float inputGallons = Int32.Parse(gallonsFuel.Text);
            float outputMileage = inputMiles / inputGallons;

            FindViewById<TextView>(Resource.Id.MileageOutput).Text = outputMileage.ToString();
          }

        }



    }
}
