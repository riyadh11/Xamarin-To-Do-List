using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
	public class TodoListPageCS : ContentPage
    {
        
		ListView listView;
        xTodoItemManager manager = xTodoItemManager.DefaultManager;

		public TodoListPageCS()
		{
			Title = "Todo List!";

			var toolbarItem = new ToolbarItem
			{
				Text = "+",
#pragma warning disable CS0618 // Type or member is obsolete
                Icon = Device.OnPlatform(null, "plus.png", "plus.png")
#pragma warning restore CS0618 // Type or member is obsolete
            };
			toolbarItem.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new TodoItemPageCS
				{
					BindingContext = new xTodoItem()
				});
			};
			ToolbarItems.Add(toolbarItem);

			listView = new ListView
			{
				Margin = new Thickness(20),
				ItemTemplate = new DataTemplate(() =>
				{
					var label = new Label
					{
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalOptions = LayoutOptions.StartAndExpand
					};
					label.SetBinding(Label.TextProperty, "Nama");

					var tick = new Image
					{
						Source = ImageSource.FromFile("check.png"),
						HorizontalOptions = LayoutOptions.End
					};
					tick.SetBinding(VisualElement.IsVisibleProperty, "Done");

					var stackLayout = new StackLayout
					{
						Margin = new Thickness(20, 0, 0, 0),
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = { label, tick }
					};

					return new ViewCell { View = stackLayout };
				})
			};
			listView.ItemSelected += async (sender, e) =>
			{
				await Navigation.PushAsync(new TodoItemPageCS
				{
					BindingContext = e.SelectedItem as xTodoItem
				});
			};

			Content = listView;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
            await RefreshItems(true, true);
            
            
		}

        public async void OnSyncItems(object sender, EventArgs e)
        {
            await RefreshItems(true, true);
        }

        private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
        {
               listView.ItemsSource = await manager.GetTodoItemsAsync();
            
        }

    }
}
