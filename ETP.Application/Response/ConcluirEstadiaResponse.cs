namespace ETP.Application.Response
{
    public sealed record class ConcluirEstadiaResponse (
        string CarroPlaca,
        decimal ValorTotal);
}
