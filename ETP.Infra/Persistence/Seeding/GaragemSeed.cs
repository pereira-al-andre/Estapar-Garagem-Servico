using ETP.Domain.Entities;
using System.Reflection;
using System.Text.Json;

namespace ETP.Infra.Persistence.Seeding
{
    internal sealed record GaragemJsonSchema (List<GaragemJson> Garagens);

    internal sealed record GaragemJson (
        string Codigo,
        string Nome,
        decimal Preco_1aHora,
        decimal Preco_HorasExtra,
        decimal Preco_Mensalista);

    public sealed class GaragemSeed
    {
        public static List<Garagem> Create()
        {
            try
            {
                GaragemJsonSchema seed = new GaragemJsonSchema(new List<GaragemJson>()
                {
                    new GaragemJson("EVO01", "Estamplaza Vila Olimpia", 40, 10, 550),
                    new GaragemJson("PLJK01", "Plaza JK", 35, 12, 380),
                    new GaragemJson("SZJK01", "Spazio JK", 30, 15, 350)
                });

                List<Garagem> entity = new();

                seed.Garagens.ForEach(g => entity.Add(new Garagem(
                    g.Codigo,
                    g.Nome,
                    g.Preco_1aHora,
                    g.Preco_HorasExtra,
                    g.Preco_Mensalista)));

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
