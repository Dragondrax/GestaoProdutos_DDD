namespace GestaoProdutos.Produtos.Application.Dto
{
    public class ProdutoFornecedorDto
    {
        public int CodigoProduto { get;set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoProduto { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
        public bool SituacaoFornecedor { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
