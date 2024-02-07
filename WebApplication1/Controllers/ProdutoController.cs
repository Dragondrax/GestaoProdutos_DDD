using Canducci.Pagination;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto(ProdutoRequestSaveModel produto)
        {
            await _produtoService.AdicionarProduto(produto);
            return Ok(new
            {
                Sucesso = true,
                Object = produto
            });
        }
        [HttpPut("AtualizarProduto")]
        public async Task<IActionResult> AtualizarProduto(ProdutoRequestEditModel produto)
        {
            await _produtoService.AtualizarProduto(produto);
            return Ok(new
            {
                Sucesso = true,
                Object = produto
            });
        }
        [HttpDelete("ExcluirProduto")]
        public async Task<IActionResult> ExcluirProduto(int codigoProduto)
        {
            await _produtoService.ExcluirProduto(codigoProduto);
            return Ok(new
            {
                Sucesso = true,
                Object = codigoProduto
            });
        }

        [HttpGet("RetornarProdutoPorCodigo")]
        public async Task<IActionResult> RetornarPorCodigo(int codigoProduto)
        {
            var result = await _produtoService.ObterProdutoPorCodigoProduto(codigoProduto);
            return Ok(new
            {
                Sucesso = true,
                Object = result
            });
        }
        [HttpGet("RetornarListaProdutosPorSituacao")]
        public async Task<IActionResult> ObterListaProdutosPorSituacao(bool situacaoProduto, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoService.ObterListaProdutosPorSituacao(situacaoProduto);

            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("RetornarListaProdutosPorDataDeValidadeEspecifica")]
        public async Task<IActionResult> ObterListaProdutosPorDataDeValidadeEspecifica(DateTime dataValidade, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoService.ObterListaProdutosPorDataDeValidadeEspecifica(dataValidade);

            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("RetornarListaProdutosPorDataDeFabricacaoEspecifica")]
        public async Task<IActionResult> ObterListaProdutosPorDataDeFabricacaoEspecifica(DateTime dataFabricacao, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoService.ObterListaProdutosPorDataDeFabricacaoEspecifica(dataFabricacao);
            
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
        [HttpGet("RetornarListaProdutosPorCodigoDoFornecedor")]
        public async Task<IActionResult> ObterListaProdutosPorCodigoFornecedor(int codigoFornecedor, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _produtoService.ObterListaProdutosPorCodigoFornecedor(codigoFornecedor);
            
            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
    }
}
