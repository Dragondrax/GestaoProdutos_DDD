namespace GestaoProdutos.Produtos.Application.Dto
{
    public class ProdutoDto
    {
        public int Codigo { get; set; }
        public int CodigoFornecedor { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
