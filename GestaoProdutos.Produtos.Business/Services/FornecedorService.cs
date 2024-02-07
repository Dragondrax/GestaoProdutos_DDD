using AutoMapper;
using GestaoProdutos.Core.DomainObjects;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Produtos.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task AdicionarFornecedor(FornecedorRequestSaveModel fornecedorDto)
        {
            var fornecedorExistente = await _fornecedorRepository.ObterPorCnpjFornecedor(fornecedorDto.Cnpj);
            if(fornecedorExistente is null)
            {
                var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                fornecedor.ValidarCriar();

                await _fornecedorRepository.Adicionar(fornecedor);
                await _fornecedorRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("fornecedor ja existente encontrado");
        }

        public async Task AtualizarFornecedor(FornecedorRequestEditModel fornecedorDto)
        {
            var fornecedorExistente = await _fornecedorRepository.ObterPorCodigoFornecedor(fornecedorDto.Codigo);

            if(fornecedorExistente is not null)
            {
                var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                fornecedor.ValidarAtualizar();

                await _fornecedorRepository.Atualizar(fornecedor);
                await _fornecedorRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("fornecedor nao encontrado");
        }

        public async Task ExcluirFornecedor(int codigoFornecedor)
        {
            var fornecedor = await _fornecedorRepository.ObterPorCodigoFornecedor(codigoFornecedor);
            if(fornecedor is not null)
            {
                await _fornecedorRepository.Excluir(fornecedor);
                await _fornecedorRepository.UnitOfWork.Commit();

                return;
            }

            throw new DomainException("fornecedor nao encontrado");
        }

        public async Task<FornecedorDto> ObterFornecedorPorCnpj(string cnpjFornecedor)
        {
            var fornecedorFiltrado = await _fornecedorRepository.ObterPorCnpjFornecedor(cnpjFornecedor);

            if (fornecedorFiltrado is not null)
                return _mapper.Map<FornecedorDto>(fornecedorFiltrado);

            throw new DomainException("fornecedor nao encontrado");
        }

        public async Task<FornecedorDto> ObterFornecedorPorCodigo(int codigoFornecedor)
        {
            var fornecedorFiltrado = await _fornecedorRepository.ObterPorCodigoFornecedor(codigoFornecedor);

            if (fornecedorFiltrado is not null)
                return _mapper.Map<FornecedorDto>(fornecedorFiltrado);

            throw new DomainException("fornecedor nao encontrado");
        }

        public async Task<IEnumerable<FornecedorDto>> ObterListaFornecedorPorSituacao(bool situacaoFornecedor)
        {
            var fornecedorFiltrado = await _fornecedorRepository.ObterListaPorSituacaoFornecedor(situacaoFornecedor);

            if (fornecedorFiltrado is not null && fornecedorFiltrado.Any())
                return _mapper.Map<IEnumerable<FornecedorDto>>(fornecedorFiltrado).OrderBy(x => x.Codigo);

            throw new DomainException("fornecedor nao encontrado");
        }
    }
}
