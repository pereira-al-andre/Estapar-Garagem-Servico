namespace ETP.Application.Commands
{
    public record class AdicionarPassagemCommand (
       string CodGaragem,
       string CarroPlaca,
       string CarroMarca,
       string CarroModelo,
       string CodFormaPagamento,
       DateTime DataHoraEntrada);
}
