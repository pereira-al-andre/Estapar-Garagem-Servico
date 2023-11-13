using ETP.Domain.Entities;
using ETP.Infra.Repositories.Common;
using ETP.Infra.Persistence;
using ETP.Domain.Repository;

namespace ETP.Infra.Repositories
{
    public sealed class FormaPagamentoRepository : Repository<FormasPagamento>, IFormaPagamentoRepository    
    {
        public FormaPagamentoRepository(SqlServerDBContext context) : base(context)
        { }
    }
}
