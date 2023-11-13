using ETP.Domain.Entities;
using System.Reflection;
using System.Text.Json;

namespace ETP.Infra.Persistence.Seeding
{
    internal sealed record FormasPagamentoJsonSchema(List<FormasPagamentoJson> FormasPagamento);

    internal sealed record FormasPagamentoJson(
        string Codigo,
        string Descricao);

    public sealed class FormasPagamentoSeed
    {
        public static List<FormasPagamento> Create()
        {
            try
            {
                FormasPagamentoJsonSchema seed = new FormasPagamentoJsonSchema(new List<FormasPagamentoJson>()
                {
                    new FormasPagamentoJson("DIN", "Dinheiro"),
                    new FormasPagamentoJson("MEN", "Mensalista"),
                    new FormasPagamentoJson("PIX", "PIX"),
                    new FormasPagamentoJson("TAG", "TAG"),
                    new FormasPagamentoJson("CDE", "Cartão de Débito"),
                    new FormasPagamentoJson("CCR", "Cartão de Crédito"),
                });

                List<FormasPagamento> entity = new();

                seed.FormasPagamento.ForEach(g => entity.Add(new FormasPagamento(
                    g.Codigo,
                    g.Descricao)));

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
