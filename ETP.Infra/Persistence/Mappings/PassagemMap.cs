using ETP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETP.Infra.Persistence.Mappings
{
    public class PassagemMap
    {
        public PassagemMap(EntityTypeBuilder<Passagem> e)
        {
            e.ToTable(Table.Passagem);

            e.HasKey(x => x.Id);

            e.Property(x => x.CodGaragem)
                .HasColumnName("CodGaragem")
                .HasColumnType("varchar(10)");

            e.Property(x => x.GaragemId)
                .HasColumnName("GaragemId")
                .IsRequired();

            e.Property(x => x.FormasPagamentoId)
                .HasColumnName("FormasPagamentoId")
                .IsRequired();

            e.Property(x => x.CarroPlaca)
                .HasColumnName("CarroPlaca")
                .IsRequired();

            e.Property(x => x.CarroMarca)
                .HasColumnName("CarroMarca")
                .IsRequired();

            e.Property(x => x.CarroModelo)
                .HasColumnName("CarroModelo")
                .IsRequired();

            e.Property(x => x.DataHoraEntrada)
                .HasColumnName("DataHoraEntrada")
                .HasColumnType("datetime");

            e.Property(x => x.DataHoraSaida)
                .HasColumnName("DataHoraSaida")
                .HasColumnType("datetime");

            e.Property(x => x.CodFormaPagamento)
                .HasColumnName("CodFormaPagamento")
                .HasColumnType("varchar(3)");

            e.Ignore(x => x.PrecoTotal); 

            e.HasOne(x => x.FormasPagamento);

            e.HasOne(x => x.Garagem)
                .WithMany(x => x.Passagens)
                .HasForeignKey(x => x.GaragemId)
                .OnDelete(DeleteBehavior.NoAction);

            e.HasOne(x => x.FormasPagamento);
        }
    }
}
