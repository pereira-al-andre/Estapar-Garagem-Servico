namespace ETP.Domain.Entities
{
    public sealed class FormasPagamento : Entity
    {
        public FormasPagamento() : base(Guid.NewGuid())
        {

        }
        public FormasPagamento(
            string codigo,
            string descricao) : base(Guid.NewGuid())
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public string Codigo { get; private set; } = null!;
        public string Descricao { get; private set; } = null!;
    }
}
