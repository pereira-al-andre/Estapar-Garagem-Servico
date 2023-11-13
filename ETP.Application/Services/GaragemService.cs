using ETP.Application.Querys;
using ETP.Application.Response;
using ETP.Application.Extensions;
using ETP.Domain.Repository;
using ETP.Application.Services;
using ETP.Application.Commands;
using ETP.Domain.Entities;
using ETP.Domain.ValuesObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ETP.Application
{
    public sealed class GaragemService : IGaragemService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository; 
        private readonly IGaragemRepository _garagemRepository; 
        private readonly IPassagemRepository _passagemRepository; 
        public GaragemService(
            IFormaPagamentoRepository formaPagamentoRepository,
            IGaragemRepository garagemRepository,
            IPassagemRepository passagemRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
            _garagemRepository = garagemRepository;
            _passagemRepository = passagemRepository;

            new SeedingService(formaPagamentoRepository, garagemRepository, passagemRepository);
        }

        public List<CarrosDoPeriodoResponse> ListarCarrosPeriodo(ListarCarrosPeriodoQuery query)
        {
            try
            {
                var garagem = _garagemRepository.Find(garagem => garagem.Codigo == query.Garagem, "Passagens");

                if (garagem == null) throw new GaragemNaoEncontradaException();

                var passagens = garagem.Passagens.Where(passagem =>
                        passagem.DataHoraEntrada >= query.DataHoraEntrada
                        && passagem.DataHoraSaida <= query.DataHoraSaida).ToList();

                return CarrosDoPeriodoResponse.ToResponseList(passagens);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CarrosAtivosResponse> ListarCarrosAtivos(string codGaragem)
        {
            try
            {

                var garagem = _garagemRepository.Find(garagem => garagem.Codigo == codGaragem, "Passagens");
               
                if (garagem == null) throw new GaragemNaoEncontradaException();

                var passagens = garagem.Passagens.Where(fp => fp.DataHoraSaida == null).ToList();

                return CarrosAtivosResponse.ToResponseList(passagens);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CarrosInativosResponse> ListarCarrosInativos(string codGaragem)
        {
            try
            {
                var garagem = _garagemRepository.Find(garagem => garagem.Codigo == codGaragem, "Passagens");

                if (garagem == null) throw new GaragemNaoEncontradaException();

                var passagens = garagem.Passagens.Where(fp => fp.DataHoraSaida != null).ToList();

                return CarrosInativosResponse.ToResponseList(passagens);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FechamentoResponse> FazerFechamento(FazerFechamentoQuery query)
        {
            try
            {
                var garagem = _garagemRepository.Find(garagem => garagem.Codigo == query.Garagem, "Passagens");

                if (garagem == null) throw new GaragemNaoEncontradaException();

                garagem.FazerFechamento(query.DataHoraEntrada, query.DataHoraSaida);

                return FechamentoResponse.ToResponseList(garagem.Passagens);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TempoMedioResponse> VerTempoMedio(VerTempoMedioQuery query)
        {
            try
            {
                var garagem = _garagemRepository.Find(garagem => garagem.Codigo == query.Garagem, "Passagens");

                if (garagem == null) throw new GaragemNaoEncontradaException();

                var passagens = garagem.Passagens.Where(fp =>
                      fp.DataHoraEntrada >= query.DataHoraSaida
                      && (fp.DataHoraSaida != null && fp.DataHoraEntrada <= query.DataHoraSaida)).ToList();

                var filter = garagem.Passagens.Select(s => new TempoMedioResponse(
                    s.CodFormaPagamento,
                    (s.DataHoraSaida.Value.Subtract(s.DataHoraEntrada).TotalMinutes / garagem.Passagens.Select(x => x.CodFormaPagamento == s.CodFormaPagamento).Count())
                    ));

                return filter.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListarTodasAsUnidadesResponse> ListarTodasAsUnidades()
        {
            try
            {
                var result = _garagemRepository.All();
                return ListarTodasAsUnidadesResponse.ToResponseList(result.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AdicionarPassagem(AdicionarPassagemCommand command)
        {
            try
            {
                var garagem = _garagemRepository.Find(g => g.Codigo == command.CodGaragem);

                if (garagem == null) throw new GaragemNaoEncontradaException();

                var formaPagamento = _formaPagamentoRepository.Find(f => f.Codigo == command.CodFormaPagamento);

                if (garagem == null) throw new FormaDePagamentoIndisponivelException(command.CodFormaPagamento);

                var passagem = new Passagem(
                    garagem, 
                    formaPagamento, 
                    new Carro(command.CarroPlaca, command.CarroMarca, command.CarroModelo), 
                    command.DataHoraEntrada);

                _passagemRepository.Create(passagem);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ConcluirEstadiaResponse ConcluirEstadia(ConcluirEstadiaCommand command)
        {
            try
            {
                var garagem = _garagemRepository.Find(g => g.Codigo == command.CodGaragem, "Passagens");

                if (garagem == null) throw new GaragemNaoEncontradaException();

                var passagem = garagem.ConcluirEstadia(command.CarroPlaca);

                return new ConcluirEstadiaResponse(passagem.CarroPlaca, passagem.PrecoTotal);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
