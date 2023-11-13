namespace ETP.Application.Extensions
{
    public sealed class GaragemNaoEncontradaException : Exception
    {
        public GaragemNaoEncontradaException() : base("A garagem informada não foi encontrada")
        {
            
        }
    }
}
