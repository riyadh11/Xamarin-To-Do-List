using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
	public class App : Application
	{

		public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryBlue", Color.FromHex("7f7fff"));
			Resources.Add("primaryDarkBlue", Color.FromHex("4c4cff"));

			var nav = new NavigationPage(new TodoListPage());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryBlue"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}


		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{

		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
			
		}
	}
}

