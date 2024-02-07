using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;

namespace GestaoProdutos.Produtos.Application.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDto>> ObterListaFornecedorPorSituacao(bool situacaoFornecedor);
        Task<FornecedorDto> ObterFornecedorPorCodigo(int codigoFornecedor);
        Task<FornecedorDto> ObterFornecedorPorCnpj(string cnpjFornecedor);
        Task AdicionarFornecedor(FornecedorRequestSaveModel fornecedorDto);
        Task AtualizarFornecedor(FornecedorRequestEditModel fornecedorDto);
        Task ExcluirFornecedor(int codigoFornecedor);
    }
}
