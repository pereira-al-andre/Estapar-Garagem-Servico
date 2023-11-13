using ETP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETP.Infra.Persistence.Mappings
{
    public class GaragemMap
    {
        public GaragemMap(EntityTypeBuilder<Garagem> e)
        {
            e.ToTable(Table.Garagem);

            e.HasKey(x => x.Id);

            e.Property(x => x.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("varchar(10)");

            e.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)");

            e.Property(x => x.PrecoHora)
                .HasColumnName("PrecoHora")
                .HasColumnType("numeric(5,2)");

            e.Property(x => x.PrecoHorasExtra)
                .HasColumnName("PrecoHorasExtra")
                .HasColumnType("numeric(5,2)");

            e.Property(x => x.PrecoMensalista)
                .HasColumnName("PrecoMensalista")
                .HasColumnType("numeric(5,2)");

            e.HasMany(x => x.Passagens)
                .WithOne(x => x.Garagem)
                .HasForeignKey(x => x.GaragemId);
        }
    }
}
