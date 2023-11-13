using ETP.Application;
using ETP.Application.Commands;
using ETP.Application.Extensions;
using ETP.Application.Querys;
using Microsoft.AspNetCore.Mvc;

namespace ETP.API.Controllers
{
    [Route("api/garagem")]
    [ApiController]
    public class GaragemController : ControllerBase
    {
        private readonly IGaragemService _garagemService;
        public GaragemController(IGaragemService garagemService)
        {
            _garagemService = garagemService;
        }

        /// <summary>
        /// Mostrar todas as unidades.
        /// </summary>
        /// <remarks>Retorna uma lista com todas as garagens cadastradas.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        [HttpGet]
        [Route("unidades")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarTodasAsUnidades()
        {
            try
            {
                var result = _garagemService.ListarTodasAsUnidades();

                return Ok(result);
            }
            catch (Exception ex) { return Problem(ex.Message); }

        }

        /// <summary>
        /// Filtrar carros por período.
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>Retorna uma listagem de todos os carros de um determinado período informado.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpGet]
        [Route("carros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarCarrosPeriodo([FromQuery]ListarCarrosPeriodoQuery query)
        {
            try
            {
                var result = _garagemService.ListarCarrosPeriodo(query);

                return Ok(result);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }

        }

        /// <summary>
        /// Mostrar carros ativos na garagem.
        /// </summary>
        /// <param name="garagem"></param>
        /// <remarks>Retorna uma lista de todos os carros ainda na garagem.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpGet]
        [Route("carros/ativos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarCarrosAtivos(string garagem)
        {
            try
            {
                var result = _garagemService.ListarCarrosAtivos(garagem);

                return Ok(result);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Mostrar carros inativos na garagem.
        /// </summary>
        /// <param name="garagem"></param>
        /// <remarks>Retorna uma lista de todos os carros que já estiveram na garagem.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpGet]
        [Route("carros/inativos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarCarrosInativos(string garagem)
        {
            try
            {
                var result = _garagemService.ListarCarrosInativos(garagem);

                return Ok(result);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Realizar balanço da geragem.
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>Faz o balanço da garagem por período.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpGet]
        [Route("fechamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult FazerFechamento([FromQuery]FazerFechamentoQuery query)
        {
            try
            {
                var result = _garagemService.FazerFechamento(query);

                return Ok(result);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Visualizar tempo médio de estadia em uma unidade.
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>Verifica as informações de tempo medio de estadia na garagem.</remarks>
        /// <reponse code="200">Busca realizada com sucesso</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpGet]
        [Route("tempomedio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult VerTempoMedio([FromQuery]VerTempoMedioQuery query)
        {
            try
            {
                var result = _garagemService.VerTempoMedio(query);

                return Ok(result);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Adiciona uma passagem na garagem.
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>Permite adicionar uma passagem na garagem.</remarks>
        /// <reponse code="200">Passagem adicionada</reponse>
        /// <reponse code="404">Garagem não encontrada</reponse>
        [HttpPost]
        [Route("passagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionaPassagem(AdicionarPassagemCommand command)
        {
            try
            {
                _garagemService.AdicionarPassagem(command);

                return Ok("Passagem adicionada.");
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }

        /// <summary>
        /// Adiciona uma passagem na garagem.
        /// </summary>
        /// <param name="query"></param>
        /// <remarks>Permite adicionar uma passagem na garagem.</remarks>
        /// <reponse code="200">Passagem adicionada</reponse>
        /// <reponse code="404">Garagem ou forma de pagamento não encontrada ou indisponível</reponse>
        [HttpPost]
        [Route("passagem/fechar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ConcluirEstadia(ConcluirEstadiaCommand command)
        {
            try
            {
                var passagem = _garagemService.ConcluirEstadia(command);

                return Ok(passagem);
            }
            catch (GaragemNaoEncontradaException ex) { return NotFound(ex.Message); }
            catch (FormaDePagamentoIndisponivelException ex) { return NotFound(ex.Message); }

            catch (Exception ex) { return Problem(ex.Message); }
        }
    }
}
