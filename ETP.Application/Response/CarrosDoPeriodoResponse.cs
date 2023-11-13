using ETP.Domain.Entities;

namespace ETP.Application.Response
{
    public sealed class CarrosDoPeriodoResponse
    {
        public CarrosDoPeriodoResponse(
            string placa,
            string marca,
            string modelo)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
        }

        public static List<CarrosDoPeriodoResponse> ToResponseList(List<Passagem> passagens)
        {
            List<CarrosDoPeriodoResponse> reponseList = new();

            passagens.ForEach(p => reponseList.Add(new CarrosDoPeriodoResponse(p.CarroPlaca, p.CarroMarca, p.CarroModelo)));

            return reponseList;
        }

        public string Placa { get; private set; } = null!;
        public string Marca { get; private set; } = null!;
        public string Modelo { get; private set; } = null!;

    }
}
