namespace ETP.Application.Querys
{
    public sealed record class VerTempoMedioQuery (
        string Garagem,
        DateTime DataHoraEntrada,
        DateTime DataHoraSaida);
}
