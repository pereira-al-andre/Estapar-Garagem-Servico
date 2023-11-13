using ETP.Domain.Contracts;
using ETP.Domain.Entities;

namespace ETP.Application.Response
{
    public sealed class FechamentoResponse
    {
        public FechamentoResponse(
            string formaPagamento,
            decimal total)
        {
            FormaPagamento = formaPagamento;
            Total = total;
        }

        public static List<FechamentoResponse> ToResponseList(List<Passagem> passagens)
        {
            List<FechamentoResponse> reponseList = new();

            var result = passagens.GroupBy(x => x.CodFormaPagamento).Select(g => new FechamentoResponse (g.Key, g.Sum(x => x.PrecoTotal)));

            return result.ToList();
        }

        public string FormaPagamento { get; private set; } = null!;
        public decimal Total { get; private set; }
    }
}

