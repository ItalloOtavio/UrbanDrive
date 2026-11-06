using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

// Os membros estaticos sao compartilhados por todos os testes.
// Esta colecao roda sozinha (sem paralelismo) para que outros testes
// criando veiculos ao mesmo tempo nao alterem o contador no meio da conta.
[CollectionDefinition("MembrosEstaticos", DisableParallelization = true)]
public class MembrosEstaticosCollection
{
}

[Collection("MembrosEstaticos")]
public class ConfiguradorSistemaTests
{
    // Contador de veiculos

    [Fact]
    public void Contador_AoCriarUmVeiculo_AumentaEmUm()
    {
        int antes = ConfiguradorSistema.TotalVeiculosCriados;

        new Veiculo(1, "ABC1D23", "Onix", 150);

        Assert.Equal(antes + 1, ConfiguradorSistema.TotalVeiculosCriados);
    }

    [Fact]
    public void Contador_AoCriarTresVeiculos_AumentaEmTres()
    {
        int antes = ConfiguradorSistema.TotalVeiculosCriados;

        new Veiculo(1, "ABC1D23", "Onix", 150);
        new Veiculo(2, "XYZ9A87", "HB20", 140);
        new Veiculo(3, "QWE4R56", "Kwid", 120);

        Assert.Equal(antes + 3, ConfiguradorSistema.TotalVeiculosCriados);
    }

    [Fact]
    public void Contador_ComVeiculoInvalido_NaoAumenta()
    {
        int antes = ConfiguradorSistema.TotalVeiculosCriados;

        Assert.Throws<ArgumentException>(() => new Veiculo(1, "", "Onix", 150));

        Assert.Equal(antes, ConfiguradorSistema.TotalVeiculosCriados);
    }

    [Fact]
    public void Contador_EhCompartilhadoEntreFrotas()
    {
        int antes = ConfiguradorSistema.TotalVeiculosCriados;
        Frota frotaA = new Frota();
        Frota frotaB = new Frota();

        frotaA.AdicionarVeiculo(new Veiculo(1, "ABC1D23", "Onix", 150));
        frotaB.AdicionarVeiculo(new Veiculo(2, "XYZ9A87", "HB20", 140));

        Assert.Equal(antes + 2, ConfiguradorSistema.TotalVeiculosCriados);
    }

    // Taxa de seguro

    [Fact]
    public void TaxaSeguro_ComValorPositivo_EhAtualizada()
    {
        double original = ConfiguradorSistema.TaxaSeguro;

        try
        {
            ConfiguradorSistema.TaxaSeguro = 25.5;

            Assert.Equal(25.5, ConfiguradorSistema.TaxaSeguro);
        }
        finally
        {
            ConfiguradorSistema.TaxaSeguro = original;
        }
    }

    [Fact]
    public void TaxaSeguro_ComZero_EhAceita()
    {
        double original = ConfiguradorSistema.TaxaSeguro;

        try
        {
            ConfiguradorSistema.TaxaSeguro = 10;
            ConfiguradorSistema.TaxaSeguro = 0;

            Assert.Equal(0, ConfiguradorSistema.TaxaSeguro);
        }
        finally
        {
            ConfiguradorSistema.TaxaSeguro = original;
        }
    }

    [Fact]
    public void TaxaSeguro_ComValorNegativo_MantemValorAnterior()
    {
        double original = ConfiguradorSistema.TaxaSeguro;

        try
        {
            ConfiguradorSistema.TaxaSeguro = 30;
            ConfiguradorSistema.TaxaSeguro = -5;

            Assert.Equal(30, ConfiguradorSistema.TaxaSeguro);
        }
        finally
        {
            ConfiguradorSistema.TaxaSeguro = original;
        }
    }
}
