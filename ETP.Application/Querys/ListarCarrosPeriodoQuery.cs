namespace ETP.Application.Querys
{
    public sealed record class ListarCarrosPeriodoQuery (
        string Garagem,
        DateTime DataHoraEntrada,
        DateTime DataHoraSaida);
}
