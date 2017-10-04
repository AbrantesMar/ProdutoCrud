using System.ComponentModel.DataAnnotations;

namespace ProductWeb.Models
{
    public enum eCategoria
    {
        [Display(Name = "BEBIDAS")]
        BEBIDAS = 1,
        [Display(Name = "FARMÁCIA")]
        FARMACIA = 2,
        [Display(Name = "LATICÍNIOS")]
        LATICINIOS = 3,
        [Display(Name = "LIMPEZA")]
        LIMPEZA = 4,
        [Display(Name = "PADARIA")]
        PADARIA = 5
    }
}