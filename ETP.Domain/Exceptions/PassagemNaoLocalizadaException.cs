namespace ETP.Domain.Extensions
{
    public sealed class PassagemNaoLocalizadaException : Exception
    {
        public PassagemNaoLocalizadaException(string carroPlaca) : base($"Nenhuma estadia ativa foi localizada para a placa ${carroPlaca}.")
        {
            
        }
    }
}
