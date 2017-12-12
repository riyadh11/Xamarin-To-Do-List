using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoListPage : ContentPage
	{
        xTodoItemManager manager;
		public TodoListPage()
		{
			InitializeComponent();
            manager = xTodoItemManager.DefaultManager;
            refresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            refresh();
        }

        async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = new xTodoItem()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{

			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as xTodoItem
			});

		}

         async void refresh()
        {
            listView.ItemsSource = await manager.GetTodoItemsAsync();
        }
	}
}
