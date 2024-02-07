using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Produtos.Application.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorSituacao(bool situacaoProduto);
        Task<ProdutoDto> ObterProdutoPorCodigoProduto(int codigoProduto);
        Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorCodigoFornecedor(int codigoFornecedor);
        Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorDataDeFabricacaoEspecifica(DateTime dataFabricacao);
        Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorDataDeValidadeEspecifica(DateTime dataValidade);
        Task AdicionarProduto(ProdutoRequestSaveModel produtoDto);
        Task AtualizarProduto(ProdutoRequestEditModel produtoDto);
        Task ExcluirProduto(int codigoProduto);
    }
}
