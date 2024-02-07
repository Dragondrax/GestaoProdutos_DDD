using Canducci.Pagination;
using GestaoProdutos.Produtos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoFornecedorController : Controller
    {
        private readonly IProdutoFornecedorService _produtoFornecedorService;
        public ProdutoFornecedorController(IProdutoFornecedorService produtoFornecedorService)
        {
            _produtoFornecedorService = produtoFornecedorService;
        }
        [HttpGet("ObterListaProdutosFornecedorPorProdutoAtivo")]
        public async Task<IActionResult> ObterListaProdutosFornecedorPorProdutoAtivo(int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorProdutoAtivo();
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }

        [HttpGet("ObterProdutosFornecedorPorCodigoDoProduto")]
        public async Task<IActionResult> ObterProdutosFornecedorPorCodigoDoProduto(int codigoProduto)
        {
            var result = await _produtoFornecedorService.ObterProdutosFornecedorPorCodigoDoProduto(codigoProduto);
            
            return Ok(new
            {
                Sucesso = true,
                Object = result
            });
        }
        [HttpGet("ObterListaProdutosFornecedorPorCnpjDoFornecedor")]
        public async Task<IActionResult> ObterListaProdutosFornecedorPorCnpjDoFornecedor(string cnpjFornecedor, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorCnpjDoFornecedor(cnpjFornecedor);
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("ObterListaProdutosFornecedorPorFornecedorAtivo")]
        public async Task<IActionResult> ObterListaProdutosFornecedorPorFornecedorAtivo(int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorFornecedorAtivo();
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("ObterListaProdutosFornecedorPorCodigoDoFornecedor")]
        public async Task<IActionResult> ObterListaProdutosFornecedorPorCodigoDoFornecedor(int codigoFornecedor, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorCodigoDoFornecedor(codigoFornecedor);
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        
        [HttpGet("ObterListaProdutosFornecedorAtivos")]
        public async Task<IActionResult> ObterListaProdutosFornecedorAtivos(int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorAtivos();
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        
        [HttpGet("ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica")]
        public async Task<IActionResult> ObterListaObterListaProdutosFornecedorPorDataDeFabricacaoEspecificaProdutosFornecedorAtivos(DateTime dataFabricacao, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(dataFabricacao);
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("ObterListaProdutosFornecedorPorDataDeValidadeEspecifica")]
        public async Task<IActionResult> ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(DateTime dataValidade, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoFornecedorService.ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(dataValidade);
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
    }
}
