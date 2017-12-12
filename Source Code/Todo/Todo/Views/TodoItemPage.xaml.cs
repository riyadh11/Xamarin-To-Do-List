using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Todo
{   
	public partial class TodoItemPage : ContentPage
	{
        xTodoItemManager manager;
		public TodoItemPage()
		{
			InitializeComponent();
            manager = xTodoItemManager.DefaultManager;
		}


        async void OnSaveClicked(object sender, EventArgs e)
		{
            var pass =  RandomString(32);
            
            if (id.Text == null)
            {
                var catat = new xTodoItem()
                {
                    Id = pass,
                    Name = txtNama.Text,
                    Description = txtCatatan.Text,
                    Done = toggleDone.IsToggled
                };

                await manager.SaveTaskAsync(catat, true);
            }
            else
            {
                var catat = new xTodoItem()
                {
                    Id = id.Text,
                    Name = txtNama.Text,
                    Description = txtCatatan.Text,
                    Done = toggleDone.IsToggled
                };
                await manager.SaveTaskAsync(catat, false);
            }


            
            await DisplayAlert("Keterangan", "Catatan Berhasil Disimpan", "OK");
            await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{

            if (id.Text != null)
            {
                var catat = new xTodoItem()
                {
                    Id = id.Text,
                    Name = txtNama.Text
                };
                await manager.delete(catat);
                await Navigation.PopAsync();
            }
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var todoItem = (xTodoItem)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Description);
		}


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
