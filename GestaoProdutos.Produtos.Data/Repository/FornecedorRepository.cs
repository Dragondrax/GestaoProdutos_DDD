using GestaoProdutos.Core.Data;
using GestaoProdutos.Produtos.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Produtos.Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ProdutosContext _context;
        public FornecedorRepository(ProdutosContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Fornecedor fornecedor)
        {
            await _context.Fornecedor.AddAsync(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            await Task.FromResult(_context.Fornecedor.Update(fornecedor));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            await Task.FromResult(_context.Fornecedor.Remove(fornecedor));
        }

        public async Task<Fornecedor> ObterPorCnpjFornecedor(string cnpjFornecedor)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(x => x.Cnpj == cnpjFornecedor);
        }

        public async Task<Fornecedor> ObterPorCodigoFornecedor(int codigoFornecedor)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(x => x.Codigo == codigoFornecedor);
        }

        public async Task<IEnumerable<Fornecedor>> ObterListaPorSituacaoFornecedor(bool situacaoFornecedor)
        {
            return await _context.Fornecedor.Where(x => x.Situacao == situacaoFornecedor).ToListAsync();
        }

        public async Task<IEnumerable<Fornecedor>> ObterListaDeFornecedores()
        {
            return await _context.Fornecedor.ToListAsync();
        }
    }
}
