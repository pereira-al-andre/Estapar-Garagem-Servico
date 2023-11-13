namespace ETP.Application.Extensions
{
    public sealed class FormaDePagamentoIndisponivelException : Exception
    {
        public FormaDePagamentoIndisponivelException(string formaPagamento) : base($"A forma de pagaamento {formaPagamento} não está disponível.")
        {
            
        }
    }
}
