using ETP.Domain.Entities;
using ETP.Domain.ValuesObjects;
using System.Reflection;
using System.Text.Json;

namespace ETP.Infra.Persistence.Seeding
{
    internal sealed record PassagemJsonSchema(List<PassagemJson> Passagens);

    internal sealed record PassagemJson (
        string Garagem,
        string CarroPlaca,
        string CarroMarca,
        string CarroModelo,
        DateTime DataHoraEntrada,
        DateTime DataHoraSaida,
        string FormaPagamento);

    public sealed class PassagemSeed
    {
        public static List<Passagem> Create(List<Garagem> garagens, List<FormasPagamento> formasPagamento)
        {
            try
            {
                PassagemJsonSchema seed = new PassagemJsonSchema(new List<PassagemJson>()
                {
                    new PassagemJson("EVO01", "AAA-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 09, 00, 00), "DIN"),
                    new PassagemJson("EVO01", "BBB-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 10, 00, 00), "MEN"),
                    new PassagemJson("EVO01", "AAA-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 11, 50, 00), "PIX"),
                    new PassagemJson("PLJK01", "BBB-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 09, 30, 00), "CDE"),
                    new PassagemJson("SZJK01", "CCC-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 14, 09, 00, 00), "CCR"),
                    new PassagemJson("PLJK01", "FFF-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 17, 00, 00), "TAG"),
                    new PassagemJson("SZJK01", "EEE-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 09, 30, 00), "CDE"),
                    new PassagemJson("SZJK01", "GGG-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 10, 00, 00), "MEN"),
                    new PassagemJson("PLJK01", "EEE-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 14, 09, 00, 00), "CCR"),
                    new PassagemJson("SZJK01", "AAA-0292", "Renault", "Sandero", new DateTime(2023, 10, 13, 08, 00, 00), new DateTime(2023, 10, 13, 17, 00, 00), "TAG"),
                });
                List<Passagem> entity = new();

                seed.Passagens.ForEach(g => entity.Add(new Passagem(
                    garagens.Find(x => x.Codigo == g.Garagem),
                    formasPagamento.First(x => x.Codigo == g.FormaPagamento),
                    new Carro(g.CarroPlaca, g.CarroPlaca, g.CarroModelo),
                    g.DataHoraEntrada,
                    g.DataHoraSaida)));

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
