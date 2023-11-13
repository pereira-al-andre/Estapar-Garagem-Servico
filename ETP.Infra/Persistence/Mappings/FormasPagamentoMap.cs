using ETP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETP.Infra.Persistence.Mappings
{
    public class FormasPagamentoMap
    {
        public FormasPagamentoMap(EntityTypeBuilder<FormasPagamento> e)
        {
            e.ToTable(Table.FormasPagamento);

            e.HasKey(x => x.Id);

            e.Property(x => x.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("varchar(3)");

            e.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(50)");
        }
    }
}
