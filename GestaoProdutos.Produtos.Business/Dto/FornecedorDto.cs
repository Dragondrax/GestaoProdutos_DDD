namespace GestaoProdutos.Produtos.Application.Dto
{
    public class FornecedorDto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
