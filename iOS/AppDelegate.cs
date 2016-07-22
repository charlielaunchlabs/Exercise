using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;

namespace Exercise.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			this.SetIoc();
			global::Xamarin.Forms.Forms.Init();
			var container = new SimpleContainer();
			container.Register<IDevice>(t => AppleDevice.CurrentDevice);
			container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
			container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppiOS();
			app.Init(this);

			var documents = app.AppDataDirectory;
			//var pathToDatabase = Path.Combine(documents, "xforms.db");

			resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IMediaPicker, MediaPicker>()
				//.Register<IJsonSerializer, Services.Serialization.ServiceStackV3.JsonSerializer>()
				.Register<IXFormsApp>(app)
				.Register<IDependencyContainer>(t => resolverContainer);
			//.Register<ISimpleCache>(
			//	t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(),
			//		new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

