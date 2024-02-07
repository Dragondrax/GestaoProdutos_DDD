using GestaoProdutos.Core.Data;

namespace GestaoProdutos.Produtos.Domain
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterListaPorSituacaoProduto(bool situacaoProduto);
        Task<Produto> ObterPorCodigoProduto(int codigoProduto);
        Task<IEnumerable<Produto>> ObterListaPorCodigoFornecedor(int codigoFornecedor);
        Task<IEnumerable<Produto>> ObterListaPorDataDeFabricacaoEspecifica(DateTime dataFabricacao);
        Task<IEnumerable<Produto>> ObterListaPorDataDeValidadeEspecifica(DateTime dataValidade);
        Task<IEnumerable<Produto>> ObterListaDeProdutos();
        Task<ProdutoFornecedor> ObterProdutosFornecedorPorCodigoDoProduto(int codigoProduto);
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorProdutoAtivo();
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorFornecedorAtivo();
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(DateTime dataValidade);
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(DateTime dataFabricacao);
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorCodigoDoFornecedor(int codigoFornecedor);
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorCnpjDoFornecedor(string cnpjFornecedor);
        Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorAtivos();
        Task Adicionar(Produto pedido);
        Task Atualizar(Produto pedido);
        Task Excluir(Produto pedido);
    }
}
