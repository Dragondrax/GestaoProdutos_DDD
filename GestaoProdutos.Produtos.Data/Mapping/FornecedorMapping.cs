using GestaoProdutos.Produtos.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Produtos.Data.Mapping
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Descricao)
                   .HasColumnType("varchar(500)")
                   .IsRequired();

            builder.Property(x => x.Cnpj)
                   .HasColumnType("varchar(14)")
                   .IsRequired();

            builder.HasIndex(x => x.Cnpj);

            builder.ToTable("Fornecedor");
        }
    }
}
