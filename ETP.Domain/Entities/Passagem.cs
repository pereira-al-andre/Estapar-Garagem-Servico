using ETP.Domain.Contracts;
using ETP.Domain.ValuesObjects;

namespace ETP.Domain.Entities
{
    public sealed class Passagem : Entity
    {
        public Passagem() : base(Guid.NewGuid())
        { } 

        public Passagem(
            Garagem garagem,
            FormasPagamento formaPagamento,
            Carro carro,
            DateTime entrada,
            DateTime saida) : base(Guid.NewGuid())
        {
            CodGaragem = garagem.Codigo;
            GaragemId = garagem.Id;
            CarroPlaca = carro.Placa;
            CarroMarca = carro.Marca;
            CarroModelo = carro.Modelo;
            CodFormaPagamento = formaPagamento.Codigo;
            FormasPagamentoId = formaPagamento.Id;
            DataHoraEntrada = entrada;
            DataHoraSaida = saida;
        }

        public Passagem(
           Garagem garagem,
           FormasPagamento formaPagamento,
           Carro carro,
           DateTime entrada) : base(Guid.NewGuid())
        {
            CodGaragem = garagem.Codigo;
            GaragemId = garagem.Id;
            CarroPlaca = carro.Placa;
            CarroMarca = carro.Marca;
            CarroModelo = carro.Modelo;
            CodFormaPagamento = formaPagamento.Codigo;
            FormasPagamentoId = formaPagamento.Id;
            DataHoraEntrada = entrada;
        }

        public string CodGaragem { get; private set; } = null!;
        public Guid FormasPagamentoId { get; private set; }
        public Guid GaragemId { get; private set; }
        public string CarroPlaca { get; private set; }
        public string CarroMarca { get; private set; }
        public string CarroModelo { get; private set; }
        public DateTime DataHoraEntrada { get; private set; }
        public DateTime? DataHoraSaida { get; private set; } = null;
        public string CodFormaPagamento { get; private set; } = null!;

        public decimal PrecoTotal { get; private set; }

        internal void CalcularSaida(FechamentoPolicy policy)
        {
            if (DataHoraSaida == null) throw new Exception("Não é possível calcular saída de uma estadia ativa.");
            
            PrecoTotal = policy.Calcular(DataHoraEntrada, DataHoraSaida.Value, CodFormaPagamento);
        }

        internal void ConcluirEstadia() => DataHoraSaida = DateTime.Now;
        internal void ConcluirEstadia(DateTime horaSaida) => DataHoraSaida = horaSaida;

        public Garagem Garagem { get; private set; } = null!;
        public FormasPagamento FormasPagamento { get; private set; } = null!;
    }
}
