using ETP.Domain.Contracts;
using ETP.Domain.Extensions;

namespace ETP.Domain.Entities
{
    public sealed class Garagem : Entity
    {
        public Garagem() : base(Guid.NewGuid())
        {

        }

        public Garagem(
            string codigo,
            string nome,
            decimal precoHora,
            decimal precoHorasExtra,
            decimal precoMensalista) : base(Guid.NewGuid())
        {
            Codigo = codigo;
            Nome = nome;
            PrecoHora = precoHora;
            PrecoHorasExtra = precoHorasExtra;
            PrecoMensalista = precoMensalista;
        }

        public string Codigo { get; private set; } = null!;
        public string Nome { get; private set; } = null!;
        public decimal PrecoHora { get; private set; }
        public decimal PrecoHorasExtra { get; private set; }
        public decimal PrecoMensalista { get; private set; }

        public List<Passagem> Passagens { get; private set; } = new();

        public FechamentoPolicy FechamentoPolicy => new FechamentoPolicy(this.PrecoHora, this.PrecoHorasExtra, this.PrecoMensalista);

        public void FazerFechamento(DateTime horarioEntrada, DateTime horarioSaida)
        {
            var passagens = Passagens.
                Where(fp => (fp.DataHoraSaida != null) && fp.DataHoraEntrada >= horarioEntrada && fp.DataHoraSaida <= horarioSaida)
                .ToList();

            foreach (var passagem in passagens) passagem.CalcularSaida(FechamentoPolicy);
        }

        public void AdicionarPassagem(Passagem passagem)
        {
            Passagens.Add(passagem);
        }

        public Passagem ConcluirEstadia(string carroPlaca)
        {
            var passagem = Passagens.Find(p => p.CarroPlaca == carroPlaca);

            if (passagem == null) throw new PassagemNaoLocalizadaException(carroPlaca);

            passagem.ConcluirEstadia();

            passagem.CalcularSaida(FechamentoPolicy);

            return passagem;
        }

        public Passagem ConcluirEstadia(string carroPlaca, DateTime horaSaida)
        {
            var passagem = Passagens.Find(p => p.CarroPlaca == carroPlaca);

            if (passagem == null) throw new PassagemNaoLocalizadaException(carroPlaca);

            passagem.ConcluirEstadia(horaSaida);

            passagem.CalcularSaida(FechamentoPolicy);

            return passagem;
        }

    }
}
