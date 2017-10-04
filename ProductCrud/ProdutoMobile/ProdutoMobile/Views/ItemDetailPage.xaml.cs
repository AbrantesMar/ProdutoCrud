
using ProdutoMobile.ViewModels;

using Xamarin.Forms;

namespace ProdutoMobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		ProdutoDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ProdutoDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
