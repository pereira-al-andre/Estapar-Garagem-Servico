using ETP.Application.Commands;
using ETP.Application.Querys;
using ETP.Application.Response;
using ETP.Domain.Entities;

namespace ETP.Application
{
    public interface IGaragemService
    {
        public List<ListarTodasAsUnidadesResponse> ListarTodasAsUnidades();
        public List<CarrosDoPeriodoResponse> ListarCarrosPeriodo(ListarCarrosPeriodoQuery query);
        public List<CarrosAtivosResponse> ListarCarrosAtivos(string garagem);
        public List<CarrosInativosResponse> ListarCarrosInativos(string garagem);
        public List<FechamentoResponse> FazerFechamento(FazerFechamentoQuery query);
        public List<TempoMedioResponse> VerTempoMedio(VerTempoMedioQuery query);
        public void AdicionarPassagem(AdicionarPassagemCommand command);
        public ConcluirEstadiaResponse ConcluirEstadia(ConcluirEstadiaCommand command);
    }
}
