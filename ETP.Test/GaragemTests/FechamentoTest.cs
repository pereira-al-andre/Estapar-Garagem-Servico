using ETP.Application;
using ETP.Application.Querys;
using ETP.Domain.Entities;
using ETP.Domain.Repository;
using ETP.Domain.ValuesObjects;
using Moq;
using Shouldly;
using System.Linq.Expressions;

namespace ETP.Test.GaragemTests
{
    public class FechamentoTest
    {
        private IFormaPagamentoRepository _formaPagamentoRepository;
        private IGaragemRepository _garagemRepository;
        private IPassagemRepository _passagemRepository;

        private GaragemService _garagemService;
        private Mock<IGaragemRepository> _garagemRepositoryMock;
        private Mock<IFormaPagamentoRepository> _formaPagamentoRepositoryMock;
        private Mock<IPassagemRepository> _passagemRepositoryMock;

        private FazerFechamentoQuery _request;

        
        public FechamentoTest()
        {
            _formaPagamentoRepositoryMock = new Mock<IFormaPagamentoRepository>();
            _garagemRepositoryMock = new Mock<IGaragemRepository>();
            _passagemRepositoryMock = new Mock<IPassagemRepository>();

          
        }

        public Garagem GaragemMock() => new Garagem("TEST", "GaragemTeste", 10, 5, 100);
        public FormasPagamento FormaPagamentoMock() => new FormasPagamento("PIX", "PIX");
        public Carro CarroMock() => new Carro("AAA-0000", "Renault", "Sandero");


        [Fact]
        public void FazerFechamento_Should_ReturnFazerFechamentoReponseWhenValid()
        {

            var _garagem = GaragemMock();
            var _formaPagamento = FormaPagamentoMock();
            var _carro = CarroMock();

            var horaEntrada = new DateTime(2023, 11, 13, 10, 00, 00);
            var horaSaida = new DateTime(2023, 11, 13, 11, 00, 00);

            var passagem = new Passagem(_garagem, _formaPagamento, _carro, horaEntrada, horaSaida);

            _garagem.AdicionarPassagem(passagem);

            _garagem.ConcluirEstadia(_carro.Placa, horaSaida);

            _garagemRepositoryMock.Setup(x => x.Find(It.IsAny<Expression<Func<Garagem, bool>>>(), "Passagens")).Returns(_garagem);

            _formaPagamentoRepository = _formaPagamentoRepositoryMock.Object;
            _passagemRepository = _passagemRepositoryMock.Object;
            _garagemRepository = _garagemRepositoryMock.Object;

            _garagemService = new GaragemService(_formaPagamentoRepository, _garagemRepository, _passagemRepository);

            _request = new FazerFechamentoQuery(_garagem.Codigo, horaEntrada, horaSaida);

            var result = _garagemService.FazerFechamento(_request);

            result.Count.ShouldBe(1);
            result.FirstOrDefault().Total.ShouldBe(10);
        }
    }
}
