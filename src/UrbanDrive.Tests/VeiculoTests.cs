using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

public class VeiculoTests
{
    private static Veiculo CriarVeiculoValido()
    {
        return new Veiculo(1, "ABC1D23", "Onix", 150);
    }

    // Criacao com dados validos

    [Fact]
    public void Construtor_ComDadosValidos_PreservaTodosOsValores()
    {
        Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

        Assert.Equal(1, veiculo.Id);
        Assert.Equal("ABC1D23", veiculo.Placa);
        Assert.Equal("Onix", veiculo.Modelo);
        Assert.Equal(150, veiculo.ValorBaseDiaria);
    }

    // Validacoes no construtor

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Construtor_ComPlacaInvalida_LancaArgumentException(string? placa)
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Veiculo(1, placa!, "Onix", 150));

        Assert.Contains("Placa", ex.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Construtor_ComModeloInvalido_LancaArgumentException(string? modelo)
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Veiculo(1, "ABC1D23", modelo!, 150));

        Assert.Contains("Modelo", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Construtor_ComValorDiariaMenorOuIgualAZero_LancaArgumentOutOfRangeException(double valorDiaria)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Veiculo(1, "ABC1D23", "Onix", valorDiaria));

        Assert.Equal(nameof(Veiculo.ValorBaseDiaria), ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Construtor_ComIdMenorOuIgualAZero_LancaArgumentOutOfRangeException(int id)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Veiculo(id, "ABC1D23", "Onix", 150));

        Assert.Equal(nameof(Veiculo.Id), ex.ParamName);
    }

    // Validacoes ao alterar as propriedades depois da criacao

    [Fact]
    public void Propriedades_AoAlterarComValoresValidos_AtualizamOsValores()
    {
        Veiculo veiculo = CriarVeiculoValido();

        veiculo.Id = 2;
        veiculo.Placa = "XYZ9K87";
        veiculo.Modelo = "HB20";
        veiculo.ValorBaseDiaria = 200;

        Assert.Equal(2, veiculo.Id);
        Assert.Equal("XYZ9K87", veiculo.Placa);
        Assert.Equal("HB20", veiculo.Modelo);
        Assert.Equal(200, veiculo.ValorBaseDiaria);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Placa_AoAlterarParaValorInvalido_LancaExcecaoEMantemValorAnterior(string? placa)
    {
        Veiculo veiculo = CriarVeiculoValido();

        Assert.Throws<ArgumentException>(() => veiculo.Placa = placa!);

        Assert.Equal("ABC1D23", veiculo.Placa);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Modelo_AoAlterarParaValorInvalido_LancaExcecaoEMantemValorAnterior(string? modelo)
    {
        Veiculo veiculo = CriarVeiculoValido();

        Assert.Throws<ArgumentException>(() => veiculo.Modelo = modelo!);

        Assert.Equal("Onix", veiculo.Modelo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ValorBaseDiaria_AoAlterarParaValorInvalido_LancaExcecaoEMantemValorAnterior(double valorDiaria)
    {
        Veiculo veiculo = CriarVeiculoValido();

        Assert.Throws<ArgumentOutOfRangeException>(() => veiculo.ValorBaseDiaria = valorDiaria);

        Assert.Equal(150, veiculo.ValorBaseDiaria);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Id_AoAlterarParaValorInvalido_LancaExcecaoEMantemValorAnterior(int id)
    {
        Veiculo veiculo = CriarVeiculoValido();

        Assert.Throws<ArgumentOutOfRangeException>(() => veiculo.Id = id);

        Assert.Equal(1, veiculo.Id);
    }
}
