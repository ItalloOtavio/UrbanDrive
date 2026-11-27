using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

public class VeiculoTests
{
    private static Veiculo CriarVeiculoValido()
    {
        return new Carro(1, "ABC1D23", "Onix", 150, 4);
    }

    // Criacao com dados validos

    [Fact]
    public void Construtor_ComDadosValidos_PreservaTodosOsValores()
    {
        Veiculo veiculo = new Carro(1, "ABC1D23", "Onix", 150, 4);

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
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Carro(1, placa!, "Onix", 150, 4));

        Assert.Contains("Placa", ex.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Construtor_ComModeloInvalido_LancaArgumentException(string? modelo)
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Carro(1, "ABC1D23", modelo!, 150, 4));

        Assert.Contains("Modelo", ex.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Construtor_ComValorDiariaMenorOuIgualAZero_LancaArgumentOutOfRangeException(double valorDiaria)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Carro(1, "ABC1D23", "Onix", valorDiaria, 4));

        Assert.Equal(nameof(Veiculo.ValorBaseDiaria), ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Construtor_ComIdMenorOuIgualAZero_LancaArgumentOutOfRangeException(int id)
    {
        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Carro(id, "ABC1D23", "Onix", 150, 4));

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

    // Sobrecarga de manutencao

    [Fact]
    public void RealizarManutencao_SemParametros_RegistraManutencaoGeral()
    {
        Veiculo veiculo = CriarVeiculoValido();

        string resultado = veiculo.RealizarManutencao();

        Assert.Contains("Manutencao geral", resultado);
        Assert.Single(veiculo.HistoricoManutencoes);
    }

    [Fact]
    public void RealizarManutencao_ComPecaSubstituida_RegistraPecaTrocada()
    {
        Veiculo veiculo = CriarVeiculoValido();

        string resultado = veiculo.RealizarManutencao("Pastilha de freio");

        Assert.Contains("Pastilha de freio", resultado);
        Assert.Single(veiculo.HistoricoManutencoes);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void RealizarManutencao_ComPecaInvalida_LancaArgumentException(string? pecaInvalida)
    {
        Veiculo veiculo = CriarVeiculoValido();

        Assert.Throws<ArgumentException>(() => veiculo.RealizarManutencao(pecaInvalida!));
    }

    // Pendencias das sprints 1 e 3 (issue #51)

    [Fact]
    public void Placa_Invalida_ExcecaoIdentificaOCampo()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Carro(1, "", "Onix", 150, 4));

        Assert.Equal("Placa", ex.ParamName);
    }

    [Fact]
    public void Modelo_Invalido_ExcecaoIdentificaOCampo()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Carro(1, "ABC1D23", "", 150, 4));

        Assert.Equal("Modelo", ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    public void CalcularAluguel_ComDiasMenorOuIgualAZero_LancaArgumentOutOfRangeException(int dias)
    {
        Veiculo carro = new Carro(1, "ABC1D23", "Onix", 150, 4);
        Veiculo patinete = new Patinete(2, "PAT0001", "Xiaomi Pro", 40, 35);

        Assert.Throws<ArgumentOutOfRangeException>(() => carro.CalcularAluguel(dias));
        Assert.Throws<ArgumentOutOfRangeException>(() => patinete.CalcularAluguel(dias));
    }
}
