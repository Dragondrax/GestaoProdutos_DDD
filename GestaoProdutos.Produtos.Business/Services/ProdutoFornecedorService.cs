using AutoMapper;
using GestaoProdutos.Core.DomainObjects;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Produtos.Application.Services
{
    public class ProdutoFornecedorService : IProdutoFornecedorService
    {
        private readonly IProdutoRepository _repositoryProduto;
        private readonly IFornecedorRepository _repositoryFornecedor;
        private readonly IMapper _mapper;

        public ProdutoFornecedorService(IProdutoRepository repositoryProduto,
                                 IFornecedorRepository repositoryFornecedor,
                                 IMapper mapper)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryFornecedor = repositoryFornecedor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorAtivos()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorAtivos());

            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos com fornecedores ativos");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }

        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorCnpjDoFornecedor(string cnpjFornecedor)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorCnpjDoFornecedor(cnpjFornecedor));

            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos pelo cnpj do fornecedor fornecido");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }

        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorCodigoDoFornecedor(int codigoFornecedor)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorCodigoDoFornecedor(codigoFornecedor));

            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos pelo codigo do fornecedor fornecido");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }

        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(DateTime dataFabricacao)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(dataFabricacao));

            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos pela data de fabricacao fornecida");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }
        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(DateTime dataValidade)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(dataValidade));
            
            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos pela data de validade fornecida");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }
        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorFornecedorAtivo()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorFornecedorAtivo());
            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos por fornecedor ativo");
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }
        public async Task<IEnumerable<ProdutoFornecedorDto>> ObterListaProdutosFornecedorPorProdutoAtivo()
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoFornecedorDto>>(await _repositoryProduto.ObterListaProdutosFornecedorPorProdutoAtivo());
            if (produtos is null || !produtos.Any())
            {
                throw new DomainException("nao foi encontrado lista de produtos por produto ativo");   
            }

            return produtos.OrderBy(x => x.CodigoProduto);
        }
        public async Task<ProdutoFornecedorDto> ObterProdutosFornecedorPorCodigoDoProduto(int codigoProtudo)
        {
            var produto = _mapper.Map<ProdutoFornecedorDto>(await _repositoryProduto.ObterProdutosFornecedorPorCodigoDoProduto(codigoProtudo));            
            if(produto is null)
                throw new DomainException("nao foi encontrado lista de produtos por codigo do produto");

            return produto;
        }
    }
}
