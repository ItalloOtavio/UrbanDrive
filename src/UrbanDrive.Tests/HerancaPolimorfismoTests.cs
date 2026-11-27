using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

// Usa ConfiguradorSistema.TaxaSeguro (estatico): roda na mesma colecao dos testes
// de membros estaticos para que outro teste nao troque a taxa no meio do calculo.
[Collection("MembrosEstaticos")]
public class HerancaPolimorfismoTests
{
    // 1. Testes de heranca e calculo especifico de cada subtipo

    [Fact]
    public void Carro_CalcularAluguel_DeveSomarTaxaSeguroPorDia()
    {
        ConfiguradorSistema.TaxaSeguro = 20.0;
        Carro carro = new Carro(1, "ABC1D23", "Onix", 150.0, 4);

        double total = carro.CalcularAluguel(3);

        // (150 * 3) + (20 * 3) = 450 + 60 = 510
        Assert.Equal(510.0, total);
        Assert.Equal(4, carro.QuantidadePortas);
    }

    [Fact]
    public void Patinete_CalcularAluguel_MenosDeSeteDias_NaoAplicaDesconto()
    {
        Patinete patinete = new Patinete(2, "PAT0001", "Xiaomi Pro", 40.0, 35);

        double total = patinete.CalcularAluguel(5);

        // 40 * 5 = 200
        Assert.Equal(200.0, total);
        Assert.Equal(35, patinete.AutonomiaBateria);
    }

    [Fact]
    public void Patinete_CalcularAluguel_SeteDiasOuMais_AplicaDescontoDeDezPorCento()
    {
        Patinete patinete = new Patinete(3, "PAT0002", "Ninebot Max", 50.0, 45);

        double total = patinete.CalcularAluguel(7);

        // (50 * 7) * 0.90 = 350 * 0.90 = 315
        Assert.Equal(315.0, total);
    }

    // 2. Testes de polimorfismo (variavel declarada como Veiculo)

    [Fact]
    public void Polimorfismo_VariavelTipoVeiculoComInstanciaCarro_UsaRegraDeCarro()
    {
        ConfiguradorSistema.TaxaSeguro = 25.0;
        Veiculo veiculo = new Carro(4, "DEF4G56", "HB20", 100.0, 4);

        double total = veiculo.CalcularAluguel(2);

        // (100 * 2) + (25 * 2) = 250
        Assert.Equal(250.0, total);
    }

    [Fact]
    public void Polimorfismo_VariavelTipoVeiculoComInstanciaPatinete_UsaRegraDePatinete()
    {
        Veiculo veiculo = new Patinete(5, "PAT0003", "Foston S09", 40.0, 25);

        double total = veiculo.CalcularAluguel(10);

        // (40 * 10) * 0.90 = 360
        Assert.Equal(360.0, total);
    }

    // 3. Testes de sobrecarga herdada nos subtipos

    [Fact]
    public void SobrecargaManutencao_EmCarroEPatinete_AmbasVersoesFuncionam()
    {
        Veiculo carro = new Carro(6, "GHI7J89", "Kwid", 120.0, 4);
        Veiculo patinete = new Patinete(7, "PAT0004", "Segway", 30.0, 30);

        string manutencaoGeralCarro = carro.RealizarManutencao();
        string manutencaoPecaCarro = carro.RealizarManutencao("Filtro de oleo");

        string manutencaoGeralPatinete = patinete.RealizarManutencao();
        string manutencaoPecaPatinete = patinete.RealizarManutencao("Bateria de litio");

        Assert.Contains("Manutencao geral", manutencaoGeralCarro);
        Assert.Contains("Filtro de oleo", manutencaoPecaCarro);
        Assert.Equal(2, carro.HistoricoManutencoes.Count);

        Assert.Contains("Manutencao geral", manutencaoGeralPatinete);
        Assert.Contains("Bateria de litio", manutencaoPecaPatinete);
        Assert.Equal(2, patinete.HistoricoManutencoes.Count);
    }

    // Pendencias da sprint 3 (issue #51)

    [Theory]
    [InlineData(0)]
    [InlineData(-2)]
    public void Carro_ComQuantidadeDePortasMenorOuIgualAZero_LancaArgumentOutOfRangeException(int portas)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Carro(1, "ABC1D23", "Onix", 150, portas));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Patinete_ComAutonomiaMenorOuIgualAZero_LancaArgumentOutOfRangeException(int autonomia)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Patinete(1, "PAT0001", "Xiaomi Pro", 40, autonomia));
    }
}
