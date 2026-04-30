using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Tests;

public class PessoaTests
{
    [Fact]
    public void Pessoa_MenorDeIdade_NaoEhMaiorDeIdade()
    {
        // Arrange
        var pessoa = new Pessoa
        {
            Nome = "Yasmin",
            DataNascimento = DateTime.Today.AddYears(-17)
        };

        // Act
        var resultado = pessoa.EhMaiorDeIdade();

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void Categoria_DeReceita_NaoPermiteDespesa()
    {
        // Arrange
        var categoria = new Categoria
        {
            Descricao = "Salário",
            Finalidade = Categoria.EFinalidade.Receita
        };

        // Act
        var resultado = categoria.PermiteTipo(Transacao.ETipo.Despesa);

        // Assert
        Assert.False(resultado);
    }

    [Fact]
    public void Categoria_DeAmbas_PermiteReceita()
    {
        // Arrange
        var categoria = new Categoria
        {
            Descricao = "Outros",
            Finalidade = Categoria.EFinalidade.Ambas
        };

        // Act
        var resultado = categoria.PermiteTipo(Transacao.ETipo.Receita);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void Pessoa_MaiorDeIdade_EhMaiorDeIdade()
    {
        // Arrange
        var pessoa = new Pessoa
        {
            Nome = "Yasmin",
            DataNascimento = DateTime.Today.AddYears(-20)
        };

        // Act
        var resultado = pessoa.EhMaiorDeIdade();

        // Assert
        Assert.True(resultado);
    }
}