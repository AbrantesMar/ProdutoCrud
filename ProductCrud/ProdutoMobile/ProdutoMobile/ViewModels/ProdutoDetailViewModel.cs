using ProdutoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoMobile.ViewModels
{
    public class ProdutoDetailViewModel : BaseViewModel
    {
        public ProdutoModel Item { get; set; }
        public ProdutoDetailViewModel(ProdutoModel item = null)
        {
            Nome = item.Nome;
            Item = item;
        }

        DateTime _dataDeCadastro = new DateTime();
        public DateTime DataDeCadastro
        {
            get { return _dataDeCadastro; }
            set { SetProperty(ref _dataDeCadastro, value); }
        }

        eCategoria _categoria = new eCategoria();
        public eCategoria Categoria
        {
            get { return _categoria; }
            set { SetProperty(ref _categoria, value); }
        }

        int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }
    }
}
