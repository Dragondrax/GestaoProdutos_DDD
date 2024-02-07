using GestaoProdutos.Core.Data;
using GestaoProdutos.Core.DomainObjects;

namespace GestaoProdutos.Produtos.Domain
{
    public class Produto : ISoftDelete
    {
        public int Codigo { get; private set; }
        public int CodigoFornecedor { get; private set; }
        public string Descricao { get; private set; }
        public bool Situacao { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Fornecedor Fornecedor { get; private set; } 

        public Produto(int codigo, int codigoFornecedor, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade)
        {
            Codigo = codigo;
            CodigoFornecedor = codigoFornecedor;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            ValidarAtualizar();
        }
        public Produto(int codigoFornecedor, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade)
        {
            CodigoFornecedor = codigoFornecedor;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;

            ValidarCriar();
        }

        public void ValidarCriar()
        {
            Validacoes.ValidarSeNulo(Situacao, "O campo descricao do produto nao pode estar vazio");
            Validacoes.ValidarSeNulo(Situacao, "O campo situacao do produto nao pode ser nulo");
            Validacoes.ValidarSeDataFabricaoEhMaiorQueDataDeValidade(DataFabricacao, DataValidade, "O campo data de fabricacao nao pode ser maior ou igual que a data de validade");
        }

        public void ValidarAtualizar()
        {
            Validacoes.ValidarSeNulo(Codigo, "O campo codigo do produto nao pode ser nulo");
            Validacoes.ValidarSeMenorIgualQue(Codigo, 0, "O campo codigo do produto nao pode ser 0");
            Validacoes.ValidarSeNulo(Situacao, "O campo descricao do produto nao pode estar vazio");
            Validacoes.ValidarSeNulo(Situacao, "O campo situacao do produto nao pode ser nulo");
            Validacoes.ValidarSeDataFabricaoEhMaiorQueDataDeValidade(DataFabricacao, DataValidade, "O campo data de fabricacao nao pode ser maior ou igual que a data de validade");
        }
    }
}
