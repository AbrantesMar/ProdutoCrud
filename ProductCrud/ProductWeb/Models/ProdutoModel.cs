using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductWeb.Models
{
    public class ProdutoModel
    {
        [Key]
        [Display(Name = "Código do produto")]
        public long Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required]
        public DateTime DataDeCadastro { get; set; }

        [Display(Name = "Nome")]
        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Categoria")]
        [Required]
        public eCategoria Categoria { get; set; }
    }
}