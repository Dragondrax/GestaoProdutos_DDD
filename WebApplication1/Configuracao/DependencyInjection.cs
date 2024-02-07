using GestaoProdutos.Produtos.Application.Services;
using GestaoProdutos.Produtos.Data;
using GestaoProdutos.Produtos.Data.Repository;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Api.Configuracao
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Context
            services.AddScoped<ProdutosContext>();

            //Produtos
            services.AddScoped<IProdutoRepository, ProdutosRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            //Services
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoFornecedorService, ProdutoFornecedorService>();
        }
    }
}
