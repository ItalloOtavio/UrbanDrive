using UrbanDrive.App;
using UrbanDrive.Models;

namespace UrbanDrive.Tests;

// O menu cria veiculos e altera a taxa de seguro (membros estaticos):
// roda na colecao sem paralelismo para nao interferir nos outros testes.
[Collection("MembrosEstaticos")]
public class MenuConsoleTests
{
    // Executa o menu com as linhas informadas como se fossem digitadas e devolve tudo o que foi escrito.
    private static string ExecutarMenu(params string[] linhas)
    {
        StringReader entrada = new StringReader(string.Join(Environment.NewLine, linhas) + Environment.NewLine);
        StringWriter saida = new StringWriter();

        new MenuConsole(entrada, saida).Executar();

        return saida.ToString();
    }

    [Fact]
    public void OpcaoInexistente_MostraErroEVoltaAoMenu()
    {
        string saida = ExecutarMenu("99", "0");

        Assert.Contains("Opção \"99\" inválida", saida);
        Assert.Contains("Sistema encerrado", saida);
    }

    [Fact]
    public void TextoNoLugarDeNumero_MostraErroEVoltaAoMenu()
    {
        // Cadastro de carro com "abc" no Id
        string saida = ExecutarMenu("1", "1", "abc", "0");

        Assert.Contains("\"abc\" não é um número inteiro válido", saida);
        Assert.Contains("Sistema encerrado", saida);
    }

    [Fact]
    public void FimDaEntrada_EncerraSemExcecao()
    {
        string saida = ExecutarMenu("3");

        Assert.Contains("Sistema encerrado", saida);
    }

    [Fact]
    public void CadastrarCarro_ApareceNaConsultaENaFrota()
    {
        string saida = ExecutarMenu(
            "1", "1", "10", "NOV1A23", "Kwid", "120", "4",
            "2", "NOV1A23",
            "3",
            "0");

        Assert.Contains("[OK] Veículo cadastrado na frota", saida);
        Assert.Contains("Modelo: Kwid | Placa: NOV1A23", saida);
        Assert.Contains("Quantidade de veículos na frota: 5", saida);
    }

    [Fact]
    public void CadastrarVeiculo_ComDadoInvalidoDoModelo_MostraMensagemDaValidacao()
    {
        // Diaria zero: Veiculo rejeita com ArgumentOutOfRangeException
        string saida = ExecutarMenu("1", "1", "10", "NOV1A23", "Kwid", "0", "4", "0");

        Assert.Contains("[ERRO] Valor da diaria invalido! Deve ser maior que zero.", saida);
        Assert.DoesNotContain("(Parameter", saida);
    }

    [Fact]
    public void CadastrarVeiculo_ComPlacaJaExistente_NaoCadastraNemContaOVeiculo()
    {
        int antes = ConfiguradorSistema.TotalVeiculosCriados;

        // O menu ja comeca com 4 veiculos (dados iniciais); ABC1D23 e um deles
        string saida = ExecutarMenu("1", "1", "10", "ABC1D23", "0");

        Assert.Contains("Já existe um veículo com a placa ABC1D23", saida);
        Assert.Equal(antes + 4, ConfiguradorSistema.TotalVeiculosCriados);
    }

    [Fact]
    public void SimularLocacao_ComCNHVencida_MostraErro()
    {
        // Motorista 2 dos dados iniciais tem CNH vencida
        string saida = ExecutarMenu("5", "2", "ABC1D23", "3", "0");

        Assert.Contains("[ERRO] CNH vencida!", saida);
    }

    [Fact]
    public void SimularLocacao_ComDadosValidos_RegistraELocacaoApareceNoRelatorio()
    {
        string saida = ExecutarMenu("5", "1", "ABC1D23", "3", "9", "0");

        Assert.Contains("[OK] Locação registrada", saida);
        Assert.Contains("Motorista: Ana Souza | Veículo: Onix | Dias: 3", saida);
    }

    [Fact]
    public void RealizarManutencao_UsaAsDuasVersoesDaSobrecarga()
    {
        string saida = ExecutarMenu("7", "ABC1D23", "", "7", "ABC1D23", "Pneu", "2", "ABC1D23", "0");

        Assert.Contains("Manutencao geral realizada no veiculo Onix", saida);
        Assert.Contains("substituicao da peca: Pneu", saida);
        Assert.Contains("Histórico de manutenções", saida);
    }

    [Fact]
    public void RecarregarEletrico_ColocaBateriaEm100()
    {
        string saida = ExecutarMenu("8", "ELE1C23", "0");

        Assert.Contains("[OK] Recarga concluída", saida);
        Assert.Contains("Bateria: 100%", saida);
    }

    [Fact]
    public void RecarregarVeiculoNaoEletrico_MostraErro()
    {
        string saida = ExecutarMenu("8", "ABC1D23", "0");

        Assert.Contains("não é elétrico", saida);
    }

    [Fact]
    public void ConfigurarTaxaNegativa_MantemTaxaAnterior()
    {
        string saida = ExecutarMenu("10", "-3", "0");

        Assert.Contains("[ERRO] Taxa inválida", saida);
        Assert.Equal(25.0, ConfiguradorSistema.TaxaSeguro);
    }
}
