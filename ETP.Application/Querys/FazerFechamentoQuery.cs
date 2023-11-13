using ETP.Domain.Entities;

namespace ETP.Application.Querys
{
    public sealed record class FazerFechamentoQuery (
        string Garagem, 
        DateTime DataHoraEntrada, 
        DateTime DataHoraSaida);
}
