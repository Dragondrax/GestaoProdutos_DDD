using GestaoProdutos.Core.Data;
using GestaoProdutos.Core.DomainObjects;

namespace GestaoProdutos.Produtos.Domain
{
    public class Fornecedor : ISoftDelete
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Cnpj { get; private set; }
        public bool Situacao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ICollection<Produto> Produto { get; set; }

        public Fornecedor(int codigo, string descricao, string cnpj) 
        { 
            Codigo = codigo;
            Descricao = descricao;
            Cnpj = cnpj;

            ValidarAtualizar();
        }
        public Fornecedor(string descricao, string cnpj)
        {
            Descricao = descricao;
            Cnpj = cnpj;

            ValidarCriar();
        }
        public void ValidarCriar()
        {
            Validacoes.ValidarSeMenorIgualQue(Codigo, 0, "O campo codigo do produto nao pode ser 0");
            Validacoes.ValidarSeNulo(Descricao, "O campo descricao do fornecedor nao pode ser nulo");
            Validacoes.ValidarSeVazio(Descricao, "O campo descricao do fornecedor nao pode estar vazio");
            Validacoes.ValidarSeNulo(Cnpj, "O campo cnpj do fornecedor nao pode ser nulo");
            Validacoes.ValidarSeVazio(Cnpj, "O campo cnpj do fornecedor nao pode ser vazio");
        }
        public void ValidarAtualizar()
        {
            Validacoes.ValidarSeMenorQue(Codigo, 0, "O campo codigo do produto nao pode ser 0");
            Validacoes.ValidarSeNulo(Descricao, "O campo descricao do fornecedor nao pode ser nulo");
            Validacoes.ValidarSeVazio(Descricao, "O campo descricao do fornecedor nao pode estar vazio");
            Validacoes.ValidarSeNulo(Cnpj, "O campo cnpj do fornecedor nao pode ser nulo");
            Validacoes.ValidarSeVazio(Cnpj, "O campo cnpj do fornecedor nao pode ser vazio");
        }
    }
}
