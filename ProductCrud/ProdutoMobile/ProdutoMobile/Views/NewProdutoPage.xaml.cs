using System;
using ProdutoMobile.Models;

using Xamarin.Forms;

namespace ProdutoMobile.Views
{
	public partial class NewProdutoPage : ContentPage
	{
        public ProdutoModel Item { get; set; }
        public NewProdutoPage ()
		{
            InitializeComponent();

            Item = new ProdutoModel
            {
                Nome = "Nome do item",
                Categoria = eCategoria.FARMACIA
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddProduto", Item);
            await Navigation.PopToRootAsync();
        }
    }
}