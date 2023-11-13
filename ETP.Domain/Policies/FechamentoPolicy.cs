namespace ETP.Domain.Contracts
{
    public class FechamentoPolicy
    {
        private readonly decimal _precoHora;
        private readonly decimal _precoHoraExtra;
        private readonly decimal _precoMensalista;

        public FechamentoPolicy(
            decimal precoHora,
            decimal precoHorasExtras,
            decimal precoMensalista)
        {
            _precoHora = precoHora;
            _precoHoraExtra = precoHorasExtras;
            _precoMensalista = precoMensalista;
        }

        public decimal Calcular(DateTime horaEntrada, DateTime horaSaida, string formaPagamento)
        {
            var timespan = horaSaida - horaEntrada;
            var tempoDecorridoEmMin = timespan.TotalMinutes;

            if (formaPagamento == "MEN") return decimal.Zero;

            if (tempoDecorridoEmMin <= 60) return _precoHora;

            int horasCompletas = (int)(tempoDecorridoEmMin / 60);
            int minutosRestantes = (int)(tempoDecorridoEmMin % 60);

            if (minutosRestantes > 30) horasCompletas++;

            return _precoHora + (horasCompletas - 1) * _precoHora;
        }
    }
}
