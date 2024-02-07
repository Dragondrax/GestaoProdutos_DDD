using GestaoProdutos.Core.Data;

namespace GestaoProdutos.Produtos.Domain
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> ObterListaPorSituacaoFornecedor(bool situacaoFornecedor);
        Task<IEnumerable<Fornecedor>> ObterListaDeFornecedores();
        Task<Fornecedor> ObterPorCodigoFornecedor(int codigoFornecedor);
        Task<Fornecedor> ObterPorCnpjFornecedor(string cnpjFornecedor);
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Excluir(Fornecedor fornecedor);
    }
}
