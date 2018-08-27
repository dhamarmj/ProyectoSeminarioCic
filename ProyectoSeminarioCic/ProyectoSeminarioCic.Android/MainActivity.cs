using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Naxam.Controls.Platform.Droid;
using Android.Graphics;
using AsNum.XFControls.Droid;
using ZXing.Mobile;
using Plugin.CurrentActivity;

namespace ProyectoSeminarioCic.Droid
{
    [Activity(Label = "SeminarioIC", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            CustomizeTabs();
            AsNumAssemblyHelper.HoldAssembly();
            MobileBarcodeScanner.Initialize(this.Application);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        private void CustomizeTabs()
        {
            var stateList = new Android.Content.Res.ColorStateList(
                new int[][]
                {
                    new int[] { Android.Resource.Attribute.StateChecked },
                    new int[] { Android.Resource.Attribute.StateEnabled }
                },
                new int[]
                {
                    Color.Gray, //Selected
                    Color.Black //Normal
                });


            // BottomTabbedRenderer.BackgroundColor = new Android.Graphics.Color(23, 31, 50);
            BottomTabbedRenderer.FontSize = 10;
            BottomTabbedRenderer.IconSize = 36;
            //  BottomTabbedRenderer.ItemTextColor = stateList;
            BottomTabbedRenderer.ItemIconTintList = stateList;
            // BottomTabbedRenderer.Typeface = Typeface.CreateFromAsset(this.Assets, "HiraginoKakugoProNW3.otf");
            //  BottomTabbedRenderer.ItemBackgroundResource = Resource.Drawable.bnv_selector;
            BottomTabbedRenderer.ItemSpacing = 5;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(0, 30, 0, 0);
            BottomTabbedRenderer.BottomBarHeight = 50;
            BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

