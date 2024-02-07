using GestaoProdutos.Produtos.Application.Dto;

namespace GestaoProdutos.Produtos.Application.Services
{
    public interface IProdutoFornecedorService
    {
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorProdutoAtivo();
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorFornecedorAtivo();
        Task<ProdutoFornecedorDto> ObterProdutosFornecedorPorCodigoDoProduto(int codigoProtudo);
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorCodigoDoFornecedor(int codigoFornecedor);
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorCnpjDoFornecedor(string cnpjFornecedor);
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(DateTime dataFabricacao);
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(DateTime dataValidade);
        Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorAtivos();
    }
}
