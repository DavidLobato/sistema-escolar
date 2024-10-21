using Moq;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using SistemaEscolar.Infrastructure.RabbitMQ;
using SistemaEscolar.Services.Implementations;

namespace SistemaEscolar.Tests
{
    public class AlunoServiceTests
    {
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock;
        private readonly Mock<RabbitMqService> _rabbitMqServiceMock;
        private readonly AlunoService _alunoService;

        public AlunoServiceTests()
        {
            // Cria mocks para as dependências
            _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _rabbitMqServiceMock = new Mock<RabbitMqService>();

            // Inicializa o serviço com os mocks
            _alunoService = new AlunoService(_alunoRepositoryMock.Object, _rabbitMqServiceMock.Object);
        }

        [Fact]
        public async Task Adicionar_Aluno_Valido_Deve_Retornar_Aluno_E_Enviar_Mensagem_RabbitMq()
        {
            // Arrange
            var aluno = new Aluno { Nome = "Teste", Email = "teste@example.com" };
            _alunoRepositoryMock.Setup(repo => repo.Adicionar(aluno)).ReturnsAsync(aluno);

            // Act
            var resultado = await _alunoService.Adicionar(aluno);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Teste", resultado.Nome);

            // Verifica se o RabbitMqService foi chamado
            _rabbitMqServiceMock.Verify(rabbit => rabbit.Publish(It.IsAny<string>()), Times.Once);
        }
    }
}