﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace leomanagement
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
                //AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
            }
        }
    }
}
