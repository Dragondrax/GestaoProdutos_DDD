using AutoMapper;
using GestaoProdutos.Produtos.Application.Dto;
using GestaoProdutos.Produtos.Application.RequestModels;
using GestaoProdutos.Produtos.Domain;

namespace GestaoProdutos.Produtos.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();

            CreateMap<ProdutoRequestSaveModel, Produto>().ReverseMap();
            CreateMap<ProdutoRequestEditModel, Produto>().ReverseMap(); 

            CreateMap<FornecedorRequestSaveModel, Fornecedor>().ReverseMap();
            CreateMap<FornecedorRequestEditModel, Fornecedor>().ReverseMap();

            CreateMap<ProdutoFornecedor, ProdutoFornecedorDto>().ReverseMap();
        }
    }
}
