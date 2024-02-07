using GestaoProdutos.Produtos.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Api.Configuracao
{
    public class ConfigureContexts
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProdutosContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("GestaoProdutos"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
