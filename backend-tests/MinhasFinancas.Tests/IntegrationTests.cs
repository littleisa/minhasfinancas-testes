using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Infrastructure.Data;

namespace MinhasFinancas.Tests;

public class IntegrationTests
{
    private MinhasFinancasDbContext CriarBanco()
    {
        var options = new DbContextOptionsBuilder<MinhasFinancasDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new MinhasFinancasDbContext(options);
    }

    [Fact]
    public async Task Pessoa_CriadaEBuscada_ComSucesso()
    {
        // Arrange
        using var banco = CriarBanco();

        var pessoa = new Pessoa
        {
            Nome = "Yasmin",
            DataNascimento = new DateTime(2000, 1, 1)
        };

        // Act
        banco.Pessoas.Add(pessoa);
        await banco.SaveChangesAsync();

        var resultado = await banco.Pessoas.FirstOrDefaultAsync(p => p.Nome == "Yasmin");

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Yasmin", resultado.Nome);
    }

    [Fact]
    public async Task Pessoa_Deletada_NaoExisteMais()
    {
        // Arrange
        using var banco = CriarBanco();

        var pessoa = new Pessoa
        {
            Nome = "Yasmin",
            DataNascimento = new DateTime(2000, 1, 1)
        };

        banco.Pessoas.Add(pessoa);
        await banco.SaveChangesAsync();

        // Act
        banco.Pessoas.Remove(pessoa);
        await banco.SaveChangesAsync();

        var resultado = await banco.Pessoas.FirstOrDefaultAsync(p => p.Nome == "Yasmin");

        // Assert
        Assert.Null(resultado);
    }
}