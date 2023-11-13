namespace ETP.Application.Response
{
    public sealed class TempoMedioResponse
    {
        public TempoMedioResponse(
            string formaPagamento,
            double media)
        {
            FormaPagamento = formaPagamento;
            Media = media;
        }

        public string FormaPagamento { get; private set; }
        public double Media { get; private set; }
    }
}
