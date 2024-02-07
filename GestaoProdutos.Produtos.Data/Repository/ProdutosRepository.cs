using Dapper;
using GestaoProdutos.Core.Data;
using GestaoProdutos.Produtos.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GestaoProdutos.Produtos.Data.Repository
{
    public class ProdutosRepository : IProdutoRepository
    {
        private readonly ProdutosContext _context;
        private const string sql = "select  p.\"Codigo\" CodigoProduto,f.\"Codigo\" CodigoFornecedor,p.\"Descricao\" DescricaoProduto,f.\"Descricao\" DescricacaoFornecedor,f.\"Cnpj\" CnpjFornecedor,f.\"Situacao\" SituacaoFornecedor,p.\"Situacao\" SituacaoProduto,p.\"DataFabricacao\",p.\"DataValidade\",p.\"DataCadastro\" DataCadastroProduto,f.\"DataCadastro\" DataCadastroFornecedor\r\nfrom public.\"Produtos\" P\r\njoin \"Fornecedor\" F on p.\"CodigoFornecedor\" = f.\"Codigo\"";
        public ProdutosRepository(ProdutosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Produto pedido)
        {
            await _context.Produtos.AddAsync(pedido);
        }

        public async Task Atualizar(Produto pedido)
        {
            await Task.FromResult(_context.Produtos.Update(pedido));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Excluir(Produto pedido)
        {
            await Task.FromResult(_context.Produtos.Remove(pedido));
        }

        public async Task<IEnumerable<Produto>> ObterListaPorCodigoFornecedor(int codigoFornecedor)
        {
            return await _context.Produtos.Where(x => x.CodigoFornecedor == codigoFornecedor).ToListAsync();
        }

        public async Task<Produto> ObterPorCodigoProduto(int codigoProduto)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Codigo == codigoProduto);
        }

        public async Task<IEnumerable<Produto>> ObterListaPorDataDeFabricacaoEspecifica(DateTime dataFabricacao)
        {
            return await _context.Produtos.Where(x => x.DataFabricacao == dataFabricacao).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterListaPorDataDeValidadeEspecifica(DateTime dataValidade)
        {
            return await _context.Produtos.Where(x => x.DataValidade == dataValidade).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterListaPorSituacaoProduto(bool situacaoProduto)
        {
            return await _context.Produtos.Where(x => x.Situacao == situacaoProduto).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterListaDeProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<ProdutoFornecedor> ObterProdutosFornecedorPorCodigoDoProduto(int codigoProduto)
        {
            var sqlFiltro = sql + "where p.\"Codigo\" = @codigoProduto";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<ProdutoFornecedor>(sqlFiltro, new { codigoProduto });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorProdutoAtivo()
        {
            var sqlFiltro = sql + "where p.\"Situacao\" = @situacao";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { situacao = true });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorFornecedorAtivo()
        {
            var sqlFiltro = sql + "where f.\"Situacao\" = @situacao";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { situacao = true });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorDataDeValidadeEspecifica(DateTime dataValidade)
        {
            var sqlFiltro = sql + "where p.\"DataValidade\" = @dataValidade";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { dataValidade });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorDataDeFabricacaoEspecifica(DateTime dataFabricacao)
        {
            var sqlFiltro = sql + "where p.\"DataFabricacao\" = @dataFabricacao";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { dataFabricacao });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorCodigoDoFornecedor(int codigoFornecedor)
        {
            var sqlFiltro = sql + "where f.\"Codigo\" = @codigoFornecedor";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { codigoFornecedor });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorPorCnpjDoFornecedor(string cnpjFornecedor)
        {
            var sqlFiltro = sql + "where f.\"Cnpj\" = @cnpjFornecedor";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { cnpjFornecedor });
            }
        }

        public async Task<IEnumerable<ProdutoFornecedor>> ObterListaProdutosFornecedorAtivos()
        {
            var sqlFiltro = sql + "where f.\"Situacao\" = @situacao";

            using (var conn = new NpgsqlConnection(_context.Connection.ConnectionString))
            {
                return await conn.QueryAsync<ProdutoFornecedor>(sqlFiltro, new { situacao = true });
            }
        }
    }
}
