namespace GestaoProdutos.Produtos.Domain
{
    public class ProdutoFornecedor
    {
        public int CodigoProduto { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoProduto { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
        public bool SituacaoFornecedor { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastroProduto { get; private set; }
        public DateTime DataCadastroFornecedor { get; private set; }
    }
}
