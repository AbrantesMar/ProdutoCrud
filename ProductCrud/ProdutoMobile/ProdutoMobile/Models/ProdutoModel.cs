using System;
using ProdutoMobile.Helpers;

namespace ProdutoMobile.Models
{
    public class ProdutoModel : ObservableObject
    {
        public long Id { get; set; }

        public DateTime DataDeCadastro { get; set; }
        
        public string Nome { get; set; }
        
        public eCategoria Categoria { get; set; }
    }
}