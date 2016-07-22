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
	public class MainActivity : XFormsApplicationDroid
	{
		protected override void OnCreate(Bundle bundle)
		{
			//TabLayoutResource = Resource.Layout.Tabbar;
			//ToolbarResource = Resource.Layout.Toolbar;

			this.SetIoc();
		
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			var container = new SimpleContainer();
			container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
			container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
			container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
			LoadApplication(new App());

		}

		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();

			app.Init(this);

			var documents = app.AppDataDirectory;
			//	var pathToDatabase = Path.Combine(documents, "xforms.db");

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
				//.Register<IJsonSerializer, Services.Serialization.JsonNET.JsonSerializer>()
				//.Register<IJsonSerializer, JsonSerializer>()
				.Register<IEmailService, EmailService>()
				.Register<IMediaPicker, MediaPicker>()
				//.Register<ITextToSpeechService, TextToSpeechService>()
				.Register<IDependencyContainer>(resolverContainer)
				.Register<IXFormsApp>(app)
							 .Register<ISecureStorage>(t => new KeyVaultStorage(t.Resolve<IDevice>().Id.ToCharArray()));
			//.Register<ICacheProvider>(
			//	t => new SQLiteSimpleCache(new SQLitePlatformAndroid(),
			//		new SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));


			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}


}

