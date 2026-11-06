using System.Reflection;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.Tests;

public class RelacionamentosTests
{
    private static Motorista CriarMotoristaValido()
    {
        return new Motorista("Ana", "12345678900", "11122233344", "B", DateTime.Today.AddYears(1));
    }

    private static Motorista CriarMotoristaComCNHVencida()
    {
        return new Motorista("Bruno", "98765432100", "55566677788", "B", DateTime.Today.AddDays(-1));
    }

    // CNH

    [Fact]
    public void CNH_ComValidadeFutura_EstaValida()
    {
        CNH cnh = new CNH("11122233344", "B", DateTime.Today.AddDays(1));

        Assert.True(cnh.EstaValida());
    }

    [Fact]
    public void CNH_QueVenceHoje_AindaEstaValida()
    {
        CNH cnh = new CNH("11122233344", "B", DateTime.Today);

        Assert.True(cnh.EstaValida());
    }

    [Fact]
    public void CNH_ComValidadePassada_EstaVencida()
    {
        CNH cnh = new CNH("11122233344", "B", DateTime.Today.AddDays(-1));

        Assert.False(cnh.EstaValida());
    }

    // Composicao: Motorista e CNH

    [Fact]
    public void Motorista_AoSerCriado_JaPossuiCNHComOsDadosInformados()
    {
        DateTime validade = DateTime.Today.AddYears(1);

        Motorista motorista = new Motorista("Ana", "12345678900", "11122233344", "B", validade);

        Assert.NotNull(motorista.Habilitacao);
        Assert.Equal("11122233344", motorista.Habilitacao.Numero);
        Assert.Equal("B", motorista.Habilitacao.Categoria);
        Assert.Equal(validade, motorista.Habilitacao.DataValidade);
    }

    [Fact]
    public void Motorista_Habilitacao_NaoPodeSerTrocadaPorFora()
    {
        PropertyInfo propriedade = typeof(Motorista).GetProperty(nameof(Motorista.Habilitacao))!;

        MethodInfo? setPublico = propriedade.GetSetMethod();

        Assert.Null(setPublico);
    }

    [Fact]
    public void Motoristas_Diferentes_TemCNHsDiferentes()
    {
        Motorista ana = CriarMotoristaValido();
        Motorista bruno = CriarMotoristaComCNHVencida();

        Assert.NotSame(ana.Habilitacao, bruno.Habilitacao);
    }

    // Agregacao: Frota e Veiculo

    [Fact]
    public void Frota_AoAdicionarVeiculo_PassaAListarOVeiculo()
    {
        Frota frota = new Frota();
        Veiculo onix = new Veiculo(1, "ABC1D23", "Onix", 150);

        bool adicionou = frota.AdicionarVeiculo(onix);

        Assert.True(adicionou);
        Assert.Single(frota.ListarVeiculos());
        Assert.Same(onix, frota.ListarVeiculos()[0]);
    }

    [Fact]
    public void Frota_ComPlacaRepetida_NaoAdicionaOSegundoVeiculo()
    {
        Frota frota = new Frota();
        frota.AdicionarVeiculo(new Veiculo(1, "ABC1D23", "Onix", 150));

        bool adicionou = frota.AdicionarVeiculo(new Veiculo(2, "ABC1D23", "HB20", 140));

        Assert.False(adicionou);
        Assert.Single(frota.ListarVeiculos());
        Assert.Equal("Onix", frota.ListarVeiculos()[0].Modelo);
    }

    [Fact]
    public void Frota_BuscarPorPlacaExistente_RetornaOVeiculo()
    {
        Frota frota = new Frota();
        Veiculo onix = new Veiculo(1, "ABC1D23", "Onix", 150);
        frota.AdicionarVeiculo(onix);
        frota.AdicionarVeiculo(new Veiculo(2, "XYZ9A87", "HB20", 140));

        Veiculo? encontrado = frota.BuscarPorPlaca("ABC1D23");

        Assert.Same(onix, encontrado);
    }

    [Fact]
    public void Frota_BuscarPorPlacaInexistente_RetornaNulo()
    {
        Frota frota = new Frota();
        frota.AdicionarVeiculo(new Veiculo(1, "ABC1D23", "Onix", 150));

        Veiculo? encontrado = frota.BuscarPorPlaca("ZZZ0Z00");

        Assert.Null(encontrado);
    }

    [Fact]
    public void Frota_AoRemoverVeiculo_VeiculoSaiDaFrotaMasContinuaExistindo()
    {
        Frota frota = new Frota();
        Veiculo onix = new Veiculo(1, "ABC1D23", "Onix", 150);
        frota.AdicionarVeiculo(onix);

        bool removeu = frota.RemoverVeiculo("ABC1D23");

        Assert.True(removeu);
        Assert.Empty(frota.ListarVeiculos());
        Assert.Null(frota.BuscarPorPlaca("ABC1D23"));
        Assert.Equal("ABC1D23", onix.Placa);
        Assert.Equal("Onix", onix.Modelo);
    }

    [Fact]
    public void Frota_AoRemoverPlacaInexistente_RetornaFalso()
    {
        Frota frota = new Frota();
        frota.AdicionarVeiculo(new Veiculo(1, "ABC1D23", "Onix", 150));

        bool removeu = frota.RemoverVeiculo("ZZZ0Z00");

        Assert.False(removeu);
        Assert.Single(frota.ListarVeiculos());
    }

    [Fact]
    public void Frota_ListarVeiculos_RetornaCopiaDaLista()
    {
        Frota frota = new Frota();
        frota.AdicionarVeiculo(new Veiculo(1, "ABC1D23", "Onix", 150));

        List<Veiculo> lista = frota.ListarVeiculos();
        lista.Clear();

        Assert.Single(frota.ListarVeiculos());
    }

    // Associacao: Locacao

    [Fact]
    public void Locacao_ComDadosValidos_LigaMotoristaEVeiculo()
    {
        Motorista motorista = CriarMotoristaValido();
        Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

        Locacao locacao = new Locacao(motorista, veiculo, 3);

        Assert.Same(motorista, locacao.Motorista);
        Assert.Same(veiculo, locacao.Veiculo);
        Assert.Equal(3, locacao.Dias);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Locacao_ComDiasMenorOuIgualAZero_LancaArgumentOutOfRangeException(int dias)
    {
        Motorista motorista = CriarMotoristaValido();
        Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

        ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Locacao(motorista, veiculo, dias));

        Assert.Equal("dias", ex.ParamName);
    }

    [Fact]
    public void Locacao_ComCNHVencida_LancaInvalidOperationException()
    {
        Motorista motorista = CriarMotoristaComCNHVencida();
        Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new Locacao(motorista, veiculo, 3));

        Assert.Contains("CNH", ex.Message);
    }

    [Fact]
    public void Locacao_SemMotorista_LancaArgumentNullException()
    {
        Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

        Assert.Throws<ArgumentNullException>(() => new Locacao(null!, veiculo, 3));
    }

    [Fact]
    public void Locacao_SemVeiculo_LancaArgumentNullException()
    {
        Motorista motorista = CriarMotoristaValido();

        Assert.Throws<ArgumentNullException>(() => new Locacao(motorista, null!, 3));
    }
}
