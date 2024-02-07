using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.Produtos.Application.RequestModels
{
    public class ProdutoRequestEditModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public int CodigoFornecedor { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public bool Situacao { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public DateTime DataFabricacao { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public DateTime DataValidade { get; set; }
    }
}
