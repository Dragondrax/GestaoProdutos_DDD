using Canducci.Pagination;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost("AdicionarFornecedor")]
        public async Task<IActionResult> AdicionarFornecedor(FornecedorRequestSaveModel fornecedorDto)
        {
            await _fornecedorService.AdicionarFornecedor(fornecedorDto);
            return Ok(new
            {
                Sucesso = true,
                Object = fornecedorDto
            });
        }

        [HttpPut("AtualizarFornecedor")]
        public async Task<IActionResult> AtualizarFornecedor(FornecedorRequestEditModel fornecedorDto)
        {
            await _fornecedorService.AtualizarFornecedor(fornecedorDto);
            return Ok(new
            {
                Sucesso = true,
                Object = fornecedorDto
            });
        }

        [HttpDelete("ExcluirFornecedor")]
        public async Task<IActionResult> AtualizarFornecedor(int codigoFornecedor)
        {
            await _fornecedorService.ExcluirFornecedor(codigoFornecedor);
            return Ok(new
            {
                Sucesso = true,
                Object = codigoFornecedor
            });
        }

        [HttpGet("ObterFornecedorPorCodigo")]
        public async Task<IActionResult> ObterFornecedorPorCodigo(int codigoFornecedor)
        {
            var result = await _fornecedorService.ObterFornecedorPorCodigo(codigoFornecedor);
            return Ok(new
            {
                Sucesso = true,
                Object = result
            });
        }
        [HttpGet("ObterFornecedorPorCnpj")]
        public async Task<IActionResult> ObterFornecedorPorCnpj(string cnpjFornecedor)
        {
            var result = await _fornecedorService.ObterFornecedorPorCnpj(cnpjFornecedor);
            return Ok(new
            {
                Sucesso = true,
                Object = result
            });
        }
        [HttpGet("ObterListaFornecedorPorSituacao")]
        public async Task<IActionResult> ObterListaFornecedorPorSituacao(bool situacaoFornecedor, int pagina, int quantidadeItensPorPagina)
        {
            var result = await _fornecedorService.ObterListaFornecedorPorSituacao(situacaoFornecedor);

            var resultadoPaginado = await result.ToPaginatedRestAsync(pagina, quantidadeItensPorPagina);

            return Ok(new
            {
                Sucesso = true,
                Object = resultadoPaginado
            });
        }
    }
}
