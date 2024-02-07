using GestaoProdutos.Api.Configuracao;
using GestaoProdutos.Core.Middleware;
using GestaoProdutos.Produtos.Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

DependencyInjection.RegisterServices(builder.Services);
ConfigureContexts.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware(typeof(MiddlewareException));

app.UseAuthorization();

app.MapControllers();

app.Run();
