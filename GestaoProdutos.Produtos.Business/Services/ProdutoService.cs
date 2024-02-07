using AutoMapper;
using GestaoProdutos.Core.DomainObjects;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Produtos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository,
                              IMapper mapper,
                              IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task AdicionarProduto(ProdutoRequestSaveModel produtoDto)
        {
            var fornecedorVinculadoAoProduto = await _fornecedorRepository.ObterPorCodigoFornecedor(produtoDto.CodigoFornecedor);
            if(fornecedorVinculadoAoProduto.Situacao)
            {
                var produto = _mapper.Map<Produto>(produtoDto);

                produto.ValidarCriar();

                await _produtoRepository.Adicionar(produto);
                await _produtoRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("fornecedor nao esta ativo");
        }

        public async Task AtualizarProduto(ProdutoRequestEditModel produtoDto)
        {
            var produtoExistente = await _produtoRepository.ObterPorCodigoProduto(produtoDto.Codigo);
            var fornecedorVinculadoAoProduto = await _fornecedorRepository.ObterPorCodigoFornecedor(produtoDto.CodigoFornecedor);

            if (produtoExistente is not null)
            {
                if (!fornecedorVinculadoAoProduto.Situacao)
                    throw new DomainException("fornecedor nao esta ativo");

                var produto = _mapper.Map<Produto>(produtoDto);

                produto.ValidarAtualizar();

                await _produtoRepository.Atualizar(produto);
                await _produtoRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("produto nao encontrado");
        }

        public async Task ExcluirProduto(int codigoProduto)
        {
            var produto = await _produtoRepository.ObterPorCodigoProduto(codigoProduto);

            if(produto is not null)
            {
                await _produtoRepository.Excluir(produto);
                await _produtoRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("produto nao encontrado");
        }

        public async Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorCodigoFornecedor(int codigoFornecedor)
        {
            var produtoFiltrado = await _produtoRepository.ObterListaPorCodigoFornecedor(codigoFornecedor);
                
            if(produtoFiltrado is not null && produtoFiltrado.Any())
                return _mapper.Map<IEnumerable<ProdutoDto>>(produtoFiltrado).OrderBy(x => x.Codigo);

            throw new DomainException("produtos nao encontrado");
        }

        public async Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorDataDeFabricacaoEspecifica(DateTime dataFabricacao)
        {
            var produtoFiltrado = await _produtoRepository.ObterListaPorDataDeFabricacaoEspecifica(dataFabricacao);

            if (produtoFiltrado is not null && produtoFiltrado.Any())
                return _mapper.Map<IEnumerable<ProdutoDto>>(produtoFiltrado).OrderBy(x => x.Codigo);

            throw new DomainException("produtos nao encontrado");
        }

        public async Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorDataDeValidadeEspecifica(DateTime dataValidade)
        {
            var produtoFiltrado = await _produtoRepository.ObterListaPorDataDeValidadeEspecifica(dataValidade);

            if (produtoFiltrado is not null && produtoFiltrado.Any())
                return _mapper.Map<IEnumerable<ProdutoDto>>(produtoFiltrado).OrderBy(x => x.Codigo);

            throw new DomainException("produtos nao encontrado");
        }

        public async Task<IEnumerable<ProdutoDto>> ObterListaProdutosPorSituacao(bool situacaoProduto)
        {
            var produtoFiltrado = await _produtoRepository.ObterListaPorSituacaoProduto(situacaoProduto);

            if (produtoFiltrado is not null && produtoFiltrado.Any())
                return _mapper.Map<IEnumerable<ProdutoDto>>(produtoFiltrado).OrderBy(x => x.Codigo);

            throw new DomainException("produtos nao encontrado");
        }

        public async Task<ProdutoDto> ObterProdutoPorCodigoProduto(int codigoProduto)
        {
            var produtoFiltrado = await _produtoRepository.ObterPorCodigoProduto(codigoProduto);

            if (produtoFiltrado is not null)
                return _mapper.Map<ProdutoDto>(produtoFiltrado);

            throw new DomainException("produto nao encontrado");
        }
    }
}
