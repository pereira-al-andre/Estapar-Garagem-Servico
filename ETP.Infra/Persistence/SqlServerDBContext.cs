using Microsoft.EntityFrameworkCore;
using ETP.Domain.Entities;
using ETP.Infra.Persistence.Mappings;
using ETP.Infra.Persistence.Seeding;

namespace ETP.Infra.Persistence
{
    public class SqlServerDBContext : DbContext
    {
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options) : base(options)
        { }

        public DbSet<Garagem> Garagem { get; set; }
        public DbSet<Passagem> Passagem { get; set; }
        public DbSet<FormasPagamento> FormasPagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var garagemSeed = GaragemSeed.Create();
            //var formasPagamento = FormasPagamentoSeed.Create();
            //var passagemSeed = PassagemSeed.Create(garagemSeed, formasPagamento);

            //builder.Entity<Garagem>().HasData(garagemSeed);
            //builder.Entity<FormasPagamento>().HasData(formasPagamento);
            //builder.Entity<Passagem>().HasData(passagemSeed);

            builder.Entity<Garagem>(e => new GaragemMap(e));
            builder.Entity<Passagem>(e => new PassagemMap(e));
            builder.Entity<FormasPagamento>(e => new FormasPagamentoMap(e));
        }
    }
}
