
using ETP.Domain.Entities;

namespace ETP.Application.Response
{
    public sealed class ListarTodasAsUnidadesResponse
    {
        public ListarTodasAsUnidadesResponse(
            string codigo,
            string nome,
            decimal precoHora,
            decimal precoHorasExtra,
            decimal precoMensalista)
        {
            Codigo = codigo;
            Nome = nome;
            PrecoHora = precoHora;
            PrecoHorasExtra = precoHorasExtra;
            PrecoMensalista = precoMensalista;
        }

        public static List<ListarTodasAsUnidadesResponse> ToResponseList(List<Garagem> garagem)
        {
            List<ListarTodasAsUnidadesResponse> reponseList = new();

            garagem.ForEach(g => reponseList.Add(new ListarTodasAsUnidadesResponse(g.Codigo, g.Nome, g.PrecoHora, g.PrecoHorasExtra, g.PrecoMensalista)));

            return reponseList;
        }

        public string Codigo { get; private set; } = null!;
        public string Nome { get; private set; } = null!;
        public decimal PrecoHora { get; private set; }
        public decimal PrecoHorasExtra { get; private set; }
        public decimal PrecoMensalista { get; private set; }
    }
}
