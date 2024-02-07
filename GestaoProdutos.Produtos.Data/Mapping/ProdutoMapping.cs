using GestaoProdutos.Produtos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProdutos.Produtos.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Codigo);

            builder.HasOne(x => x.Fornecedor)
                   .WithMany(x => x.Produto)
                   .HasForeignKey(x => x.CodigoFornecedor)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.DataFabricacao)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(x => x.DataValidade)
                   .HasColumnType("date")
                   .IsRequired();

            builder.ToTable("Produtos");
        }
    }
}
