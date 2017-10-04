using System;

using ProdutoMobile.Models;
using ProdutoMobile.ViewModels;

using Xamarin.Forms;

namespace ProdutoMobile.Views
{
	public partial class ItemsPage : ContentPage
	{
        ProdutosViewModel viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ProdutosViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
            var item = args.SelectedItem as ProdutoModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ProdutoDetailViewModel(item)));

            // Manually deselect item
            ProdutosListView.SelectedItem = null;
        }

		async void AddProduto_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewProdutoPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if (viewModel.Produtos.Count == 0)
                viewModel.LoadProdutosCommand.Execute(null);
        }
	}
}
