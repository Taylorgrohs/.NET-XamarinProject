using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace WeathApp.Droid
{
    [Activity(Label = "Sample Weather App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Home);

            Button button = FindViewById<Button>(Resource.Id.weatherButton);
            button.Click += Button3_Click;
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

        private void Button2_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Home);

            Button button = FindViewById<Button>(Resource.Id.weatherButton);

            button.Click += Button3_Click;

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);
            button.Click += Button_Click;

            Button button2 = FindViewById<Button>(Resource.Id.HomeButton);
            button2.Click += Button2_Click;

        }
    }
}

