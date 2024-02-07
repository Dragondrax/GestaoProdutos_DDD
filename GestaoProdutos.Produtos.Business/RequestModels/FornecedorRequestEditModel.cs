using GestaoProdutos.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.Produtos.Application.RequestModels
{
    public class FornecedorRequestEditModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(14, ErrorMessage = "O Campo {0} passou do limite de caracteres permitidos")]
        [Cnpj]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public bool Situacao { get; set; }
    }
}
