using System.Reflection;
using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

public class TestesFinaisIntegracaoTests
{
    // 1. Testes de Abstracao (Veiculo abstract e construtor protected)

    [Fact]
    public void Veiculo_DeveSerClasseAbstrataComConstrutorProtegido()
    {
        Type tipoVeiculo = typeof(Veiculo);

        Assert.True(tipoVeiculo.IsAbstract);
        Assert.False(tipoVeiculo.IsInterface);

        ConstructorInfo[] construtoresPublicos = tipoVeiculo.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        ConstructorInfo[] construtoresProtegidos = tipoVeiculo.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.Empty(construtoresPublicos);
        Assert.Single(construtoresProtegidos);
    }

    // 2. Testes de Interfaces (IEletrico e IImprimivel)

    [Fact]
    public void IEletrico_PatineteECarroEletrico_RecarregamPolimorficamente()
    {
        var patinete = new Patinete(1, "PAT1001", "Xiaomi Pro", 40.0, 35) { NivelBateria = 20 };
        var carroEletrico = new CarroEletrico(2, "ELE2002", "BYD Dolphin", 180.0, 4, 15);

        List<IEletrico> veiculosEletricos = new List<IEletrico> { patinete, carroEletrico };

        foreach (IEletrico eletrico in veiculosEletricos)
        {
            eletrico.Recarregar();
        }

        Assert.Equal(100, patinete.NivelBateria);
        Assert.Equal(100, carroEletrico.NivelBateria);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Patinete_NivelBateriaForaDoIntervalo_LancaArgumentOutOfRangeException(int nivelInvalido)
    {
        var patinete = new Patinete(1, "PAT1001", "Xiaomi Pro", 40.0, 35);

        Assert.Throws<ArgumentOutOfRangeException>(() => patinete.NivelBateria = nivelInvalido);
    }

    [Fact]
    public void IImprimivel_DiferentesEntidades_GeramRelatoriosEspecificos()
    {
        ConfiguradorSistema.TaxaSeguro = 20.0;
        var motorista = new Motorista("Wagner Junior", "123.456.789-00", "98765432100", "B", DateTime.Today.AddYears(3));

        var carro = new Carro(1, "ABC1D23", "Onix", 150.0, 4);
        var carroEletrico = new CarroEletrico(2, "ELE2002", "BYD Dolphin", 200.0, 4, 85);
        var patinete = new Patinete(3, "PAT1001", "Segway", 50.0, 40);
        var locacao = new Locacao(motorista, carroEletrico, 3);

        List<IImprimivel> imprimiveis = new List<IImprimivel> { carro, carroEletrico, patinete, locacao };

        List<string> relatorios = imprimiveis.Select(item => item.GerarRelatorio()).ToList();

        Assert.Contains("Onix", relatorios[0]);
        Assert.Contains("Bateria: 85%", relatorios[1]);
        Assert.Contains("[Patinete]", relatorios[2]);
        Assert.Contains("Autonomia: 40 km", relatorios[2]);
        Assert.Contains("Wagner Junior", relatorios[3]);
        Assert.Contains("660,00", relatorios[3].Replace(".", ",")); // (200 * 3) + (20 * 3) = 660
    }

    // 3. Teste de Integracao Ponta a Ponta (Frota + Locacao + Calculo + Manutencao)

    [Fact]
    public void IntegracaoCompleta_FrotaLocacaoECalculo_FluxoCompletoFunciona()
    {
        ConfiguradorSistema.TaxaSeguro = 25.0;

        var frota = new Frota();
        var carro = new Carro(10, "CAR1010", "HB20", 120.0, 4);
        var carroEletrico = new CarroEletrico(11, "ELE1111", "Ora 03", 160.0, 4, 40);
        var patinete = new Patinete(12, "PAT1212", "Ninebot", 30.0, 30);

        Assert.True(frota.AdicionarVeiculo(carro));
        Assert.True(frota.AdicionarVeiculo(carroEletrico));
        Assert.True(frota.AdicionarVeiculo(patinete));
        Assert.False(frota.AdicionarVeiculo(carro)); // Impede placa duplicada

        Veiculo? veiculoBuscado = frota.BuscarPorPlaca("ELE1111");
        Assert.NotNull(veiculoBuscado);

        // Recarrega via interface antes de alugar
        if (veiculoBuscado is IEletrico eletrico)
        {
            eletrico.Recarregar();
        }
        Assert.Equal(100, carroEletrico.NivelBateria);

        // Cria locacao com motorista valido
        var motorista = new Motorista("Wagner Junior", "123.456.789-00", "98765432100", "B", DateTime.Today.AddYears(2));
        var locacaoCarroEletrico = new Locacao(motorista, veiculoBuscado, 4);

        // Calculo polimorfico: (160 * 4) + (25 * 4) = 640 + 100 = 740
        double valorEsperadoCarro = 740.0;
        Assert.Equal(valorEsperadoCarro, locacaoCarroEletrico.Veiculo.CalcularAluguel(locacaoCarroEletrico.Dias));

        // Segunda locacao com patinete por 10 dias (desconto de 10%): (30 * 10) * 0.90 = 270
        var locacaoPatinete = new Locacao(motorista, patinete, 10);
        Assert.Equal(270.0, locacaoPatinete.Veiculo.CalcularAluguel(locacaoPatinete.Dias));

        // Registra manutencao no retorno e remove da frota
        string registroManutencao = veiculoBuscado.RealizarManutencao("Pneu dianteiro");
        Assert.Contains("Pneu dianteiro", registroManutencao);

        Assert.True(frota.RemoverVeiculo("ELE1111"));
        Assert.Equal(2, frota.ListarVeiculos().Count);
    }
}