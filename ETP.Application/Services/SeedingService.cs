using ETP.Domain.Repository;
using ETP.Infra.Persistence.Seeding;
using ETP.Infra.Repositories;

namespace ETP.Application.Services
{
    public sealed class SeedingService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        private readonly IGaragemRepository _garagemRepository;
        private readonly IPassagemRepository _passagemRepository;

        public SeedingService(
            IFormaPagamentoRepository formaPagamentoRepository,
            IGaragemRepository garagemRepository,
            IPassagemRepository passagemRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
            _garagemRepository = garagemRepository;
            _passagemRepository = passagemRepository;

            if (_formaPagamentoRepository.All().ToList().Count() == 0 &&
            _passagemRepository.All().ToList().Count() == 0 &&
            _garagemRepository.All().ToList().Count() == 0)
            {
                var garagemSeed = GaragemSeed.Create();
                var formasPagamento = FormasPagamentoSeed.Create();
                var passagemSeed = PassagemSeed.Create(garagemSeed, formasPagamento);

                garagemSeed.ForEach(g => garagemRepository.Create(g));
                formasPagamento.ForEach(fp => _formaPagamentoRepository.Create(fp));
                passagemSeed.ForEach(p => _passagemRepository.Create(p));
            }
        }
    }
}
