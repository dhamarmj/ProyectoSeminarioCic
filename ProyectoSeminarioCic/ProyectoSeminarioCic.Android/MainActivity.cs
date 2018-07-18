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

namespace ProyectoSeminarioCic.Droid
{
    [Activity(Label = "ProyectoSeminarioCic", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //klk tu dice
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CustomizeTabs();
            AsNumAssemblyHelper.HoldAssembly();
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
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(0,30,0,0);
            BottomTabbedRenderer.BottomBarHeight = 50;
            BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;
        }
    }
}

