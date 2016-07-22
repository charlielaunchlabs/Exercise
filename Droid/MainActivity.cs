using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Platform.Device;
using XLabs.Ioc;
using XLabs.Forms.Services;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Forms;

namespace Exercise.Droid
{
	[Activity(Label = "Exercise.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity :   global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{


		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			var container = new SimpleContainer();
			container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
			container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
			container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
			Resolver.SetResolver(container.GetResolver());
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
		
			LoadApplication(new App());

		}
	

	}


} 

