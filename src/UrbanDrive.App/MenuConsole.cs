using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

namespace UrbanDrive.App;

// Telas do menu do console. Cada opcao le os dados, chama as classes de UrbanDrive.Models
// e mostra o resultado. As validacoes e os calculos ficam nas classes do modelo: quando uma
// delas rejeita os dados (excecao), o menu mostra a mensagem e volta para o inicio.
public class MenuConsole
{
    private readonly TextWriter saida;
    private readonly LeitorConsole leitor;

    private readonly Frota frota = new Frota();
    private readonly List<Motorista> motoristas = new List<Motorista>();
    private readonly List<Locacao> locacoes = new List<Locacao>();

    public MenuConsole(TextReader entrada, TextWriter saida)
    {
        this.saida = saida;
        leitor = new LeitorConsole(entrada, saida);

        CarregarDadosIniciais();
    }

    public void Executar()
    {
        saida.WriteLine("==================================================");
        saida.WriteLine("         URBANDRIVE - GESTÃO DE MOBILIDADE        ");
        saida.WriteLine("==================================================");

        bool continuar = true;

        while (continuar)
        {
            MostrarOpcoes();

            try
            {
                continuar = ExecutarOpcao(leitor.LerTexto("Escolha uma opção"));
            }
            catch (FimDaEntradaException)
            {
                continuar = false;
            }
            catch (EntradaInvalidaException ex)
            {
                MostrarErro(ex.Message);
            }
            catch (ArgumentException ex)
            {
                // Inclui ArgumentNullException e ArgumentOutOfRangeException (validacoes do modelo)
                MostrarErro(MensagemSemParametro(ex));
            }
            catch (InvalidOperationException ex)
            {
                // Regra de negocio do modelo, ex.: locacao com CNH vencida
                MostrarErro(ex.Message);
            }
        }

        saida.WriteLine();
        saida.WriteLine("Sistema encerrado. Até logo!");
    }

    private void MostrarOpcoes()
    {
        saida.WriteLine();
        saida.WriteLine("------------------- MENU -------------------");
        saida.WriteLine(" 1 - Cadastrar veículo");
        saida.WriteLine(" 2 - Consultar veículo pela placa");
        saida.WriteLine(" 3 - Listar a frota");
        saida.WriteLine(" 4 - Cadastrar motorista");
        saida.WriteLine(" 5 - Simular locação");
        saida.WriteLine(" 6 - Comparar aluguel de toda a frota");
        saida.WriteLine(" 7 - Realizar manutenção");
        saida.WriteLine(" 8 - Recarregar veículo elétrico");
        saida.WriteLine(" 9 - Gerar relatórios");
        saida.WriteLine("10 - Configurar taxa de seguro");
        saida.WriteLine(" 0 - Sair");
        saida.WriteLine("--------------------------------------------");
    }

    // Devolve false quando o usuario escolhe sair.
    private bool ExecutarOpcao(string opcao)
    {
        switch (opcao)
        {
            case "1": CadastrarVeiculo(); break;
            case "2": ConsultarVeiculo(); break;
            case "3": ListarFrota(); break;
            case "4": CadastrarMotorista(); break;
            case "5": SimularLocacao(); break;
            case "6": CompararAluguel(); break;
            case "7": RealizarManutencao(); break;
            case "8": RecarregarEletrico(); break;
            case "9": GerarRelatorios(); break;
            case "10": ConfigurarTaxaSeguro(); break;
            case "0": return false;
            default: MostrarErro($"Opção \"{opcao}\" inválida. Escolha um número do menu."); break;
        }

        return true;
    }

    // 1 - Cadastro de veiculo (Carro, CarroEletrico ou Patinete)
    private void CadastrarVeiculo()
    {
        MostrarTitulo("CADASTRAR VEÍCULO");
        saida.WriteLine("Tipos: 1 - Carro | 2 - Carro elétrico | 3 - Patinete");
        string tipo = leitor.LerTexto("Tipo");

        if (tipo != "1" && tipo != "2" && tipo != "3")
        {
            MostrarErro($"Tipo \"{tipo}\" inválido. Escolha 1, 2 ou 3.");
            return;
        }

        int id = leitor.LerInteiro("Id");
        string placa = leitor.LerTexto("Placa");

        // Consulta antes de criar: um veiculo com placa repetida nao deve entrar no contador de veiculos.
        if (frota.BuscarPorPlaca(placa) != null)
        {
            MostrarErro($"Já existe um veículo com a placa {placa} na frota.");
            return;
        }

        string modelo = leitor.LerTexto("Modelo");
        double diaria = leitor.LerDecimal("Valor-base da diária (R$)");

        Veiculo veiculo;

        if (tipo == "1")
        {
            int portas = leitor.LerInteiro("Quantidade de portas");
            veiculo = new Carro(id, placa, modelo, diaria, portas);
        }
        else if (tipo == "2")
        {
            int portas = leitor.LerInteiro("Quantidade de portas");
            int bateria = leitor.LerInteiro("Nível da bateria (0 a 100)");
            veiculo = new CarroEletrico(id, placa, modelo, diaria, portas, bateria);
        }
        else
        {
            int autonomia = leitor.LerInteiro("Autonomia da bateria (km)");
            int bateria = leitor.LerInteiro("Nível da bateria (0 a 100)");
            Patinete patinete = new Patinete(id, placa, modelo, diaria, autonomia);
            patinete.NivelBateria = bateria;
            veiculo = patinete;
        }

        if (!frota.AdicionarVeiculo(veiculo))
        {
            MostrarErro($"Já existe um veículo com a placa {veiculo.Placa} na frota.");
            return;
        }

        MostrarSucesso("Veículo cadastrado na frota:");
        saida.WriteLine(veiculo.GerarRelatorio());
    }

    // 2 - Consulta pela placa
    private void ConsultarVeiculo()
    {
        MostrarTitulo("CONSULTAR VEÍCULO");
        Veiculo? veiculo = BuscarVeiculo();

        if (veiculo == null)
        {
            return;
        }

        saida.WriteLine(veiculo.GerarRelatorio());
        saida.WriteLine($"Aluguel de 1 dia: R$ {veiculo.CalcularAluguel(1):F2}");

        if (veiculo.HistoricoManutencoes.Count == 0)
        {
            saida.WriteLine("Nenhuma manutenção registrada.");
        }
        else
        {
            saida.WriteLine("Histórico de manutenções:");

            foreach (string registro in veiculo.HistoricoManutencoes)
            {
                saida.WriteLine($"  - {registro}");
            }
        }
    }

    // 3 - Listagem da frota
    private void ListarFrota()
    {
        MostrarTitulo("FROTA");
        List<Veiculo> veiculos = frota.ListarVeiculos();

        if (veiculos.Count == 0)
        {
            saida.WriteLine("A frota está vazia.");
            return;
        }

        foreach (Veiculo veiculo in veiculos)
        {
            saida.WriteLine(veiculo.GerarRelatorio());
        }

        saida.WriteLine(frota.GerarRelatorio());
    }

    // 4 - Cadastro de motorista (a CNH e criada dentro do Motorista: composicao)
    private void CadastrarMotorista()
    {
        MostrarTitulo("CADASTRAR MOTORISTA");
        string nome = leitor.LerTexto("Nome");
        string cpf = leitor.LerTexto("CPF");
        string numeroCNH = leitor.LerTexto("Número da CNH");
        string categoria = leitor.LerTexto("Categoria da CNH");
        DateTime validade = leitor.LerData("Validade da CNH");

        Motorista motorista = new Motorista(nome, cpf, numeroCNH, categoria, validade);
        motoristas.Add(motorista);

        MostrarSucesso("Motorista cadastrado:");
        saida.WriteLine(motorista.GerarRelatorio());

        if (!motorista.Habilitacao.EstaValida())
        {
            saida.WriteLine("Atenção: a CNH está vencida, então este motorista não poderá alugar veículos.");
        }
    }

    // 5 - Locacao: associa um motorista a um veiculo por alguns dias
    private void SimularLocacao()
    {
        MostrarTitulo("SIMULAR LOCAÇÃO");

        if (motoristas.Count == 0)
        {
            MostrarErro("Nenhum motorista cadastrado. Use a opção 4 primeiro.");
            return;
        }

        saida.WriteLine("Motoristas:");

        for (int i = 0; i < motoristas.Count; i++)
        {
            Motorista m = motoristas[i];
            string situacao = m.Habilitacao.EstaValida() ? "CNH válida" : "CNH vencida";
            saida.WriteLine($"  {i + 1} - {m.Nome} (CPF {m.CPF}, {situacao})");
        }

        int numero = leitor.LerInteiro("Número do motorista");

        if (numero < 1 || numero > motoristas.Count)
        {
            MostrarErro($"Motorista {numero} não existe na lista.");
            return;
        }

        Veiculo? veiculo = BuscarVeiculo();

        if (veiculo == null)
        {
            return;
        }

        int dias = leitor.LerInteiro("Quantidade de dias");

        Locacao locacao = new Locacao(motoristas[numero - 1], veiculo, dias);
        locacoes.Add(locacao);

        MostrarSucesso("Locação registrada:");
        saida.WriteLine(locacao.GerarRelatorio());
    }

    // 6 - Polimorfismo: o mesmo CalcularAluguel da regra certa para cada tipo de veiculo
    private void CompararAluguel()
    {
        MostrarTitulo("COMPARAR ALUGUEL DA FROTA");
        int dias = leitor.LerInteiro("Quantidade de dias");
        List<Veiculo> veiculos = frota.ListarVeiculos();

        if (veiculos.Count == 0)
        {
            saida.WriteLine("A frota está vazia.");
            return;
        }

        saida.WriteLine($"Taxa de seguro dos carros: R$ {ConfiguradorSistema.TaxaSeguro:F2} por dia | Patinetes: 10% de desconto a partir de 7 dias");

        foreach (Veiculo veiculo in veiculos)
        {
            saida.WriteLine($"{veiculo.Modelo} ({veiculo.Placa}) | {dias} dia(s): R$ {veiculo.CalcularAluguel(dias):F2}");
        }
    }

    // 7 - Manutencao: as duas versoes sobrecarregadas de RealizarManutencao
    private void RealizarManutencao()
    {
        MostrarTitulo("REALIZAR MANUTENÇÃO");
        Veiculo? veiculo = BuscarVeiculo();

        if (veiculo == null)
        {
            return;
        }

        string peca = leitor.LerTexto("Peça substituída (deixe vazio para manutenção geral)");

        string registro = peca == ""
            ? veiculo.RealizarManutencao()
            : veiculo.RealizarManutencao(peca);

        MostrarSucesso(registro);
    }

    // 8 - Recarga: so os veiculos que implementam IEletrico
    private void RecarregarEletrico()
    {
        MostrarTitulo("RECARREGAR VEÍCULO ELÉTRICO");
        bool temEletrico = false;

        foreach (Veiculo v in frota.ListarVeiculos())
        {
            if (v is IEletrico)
            {
                saida.WriteLine($"  {v.GerarRelatorio()}");
                temEletrico = true;
            }
        }

        if (!temEletrico)
        {
            saida.WriteLine("Não há veículos elétricos na frota.");
            return;
        }

        Veiculo? veiculo = BuscarVeiculo();

        if (veiculo == null)
        {
            return;
        }

        if (veiculo is not IEletrico eletrico)
        {
            MostrarErro($"O veículo {veiculo.Modelo} ({veiculo.Placa}) não é elétrico.");
            return;
        }

        eletrico.Recarregar();
        MostrarSucesso("Recarga concluída:");
        saida.WriteLine(veiculo.GerarRelatorio());
    }

    // 9 - Relatorios: todas as entidades pelo contrato comum IImprimivel
    private void GerarRelatorios()
    {
        MostrarTitulo("RELATÓRIOS");

        List<IImprimivel> imprimiveis = new List<IImprimivel>();
        imprimiveis.Add(frota);
        imprimiveis.AddRange(frota.ListarVeiculos());
        imprimiveis.AddRange(motoristas);
        imprimiveis.AddRange(locacoes);

        foreach (IImprimivel item in imprimiveis)
        {
            saida.WriteLine(item.GerarRelatorio());
        }

        if (locacoes.Count == 0)
        {
            saida.WriteLine("Nenhuma locação registrada.");
        }

        saida.WriteLine($"Veículos criados no sistema: {ConfiguradorSistema.TotalVeiculosCriados}");
        saida.WriteLine($"Taxa de seguro: R$ {ConfiguradorSistema.TaxaSeguro:F2} por dia");
    }

    // 10 - Membro estatico compartilhado por todos os carros
    private void ConfigurarTaxaSeguro()
    {
        MostrarTitulo("CONFIGURAR TAXA DE SEGURO");
        saida.WriteLine($"Taxa atual: R$ {ConfiguradorSistema.TaxaSeguro:F2} por dia");
        double novaTaxa = leitor.LerDecimal("Nova taxa (R$ por dia)");

        ConfiguradorSistema.TaxaSeguro = novaTaxa;

        // O ConfiguradorSistema ignora valores negativos e mantem a taxa anterior.
        if (ConfiguradorSistema.TaxaSeguro != novaTaxa)
        {
            MostrarErro($"Taxa inválida. A taxa continua R$ {ConfiguradorSistema.TaxaSeguro:F2}.");
            return;
        }

        MostrarSucesso($"Taxa de seguro alterada para R$ {ConfiguradorSistema.TaxaSeguro:F2} por dia.");
    }

    private Veiculo? BuscarVeiculo()
    {
        string placa = leitor.LerTexto("Placa");
        Veiculo? veiculo = frota.BuscarPorPlaca(placa);

        if (veiculo == null)
        {
            MostrarErro($"Nenhum veículo com a placa \"{placa}\" na frota.");
        }

        return veiculo;
    }

    // Dados de exemplo para a demonstracao ja comecar com frota e motoristas.
    private void CarregarDadosIniciais()
    {
        ConfiguradorSistema.TaxaSeguro = 25.00;

        frota.AdicionarVeiculo(new Carro(1, "ABC1D23", "Onix", 150, 4));
        frota.AdicionarVeiculo(new Carro(2, "XYZ9A87", "HB20", 140, 4));
        frota.AdicionarVeiculo(new CarroEletrico(3, "ELE1C23", "BYD Dolphin", 220, 4, 20));

        Patinete patinete = new Patinete(4, "PAT0001", "Patinete Urban", 40, 30);
        patinete.NivelBateria = 35;
        frota.AdicionarVeiculo(patinete);

        motoristas.Add(new Motorista("Ana Souza", "123.456.789-00", "11122233344", "B", DateTime.Today.AddYears(2)));
        motoristas.Add(new Motorista("Bruno Lima", "987.654.321-00", "55566677788", "B", DateTime.Today.AddDays(-10)));
    }

    // A mensagem da ArgumentException termina com " (Parameter 'nome')": para o usuario basta o texto.
    private static string MensagemSemParametro(ArgumentException ex)
    {
        string mensagem = ex.Message;
        int inicio = ex.ParamName == null ? -1 : mensagem.LastIndexOf(" (");

        return inicio > 0 ? mensagem.Substring(0, inicio) : mensagem;
    }

    private void MostrarTitulo(string titulo)
    {
        saida.WriteLine();
        saida.WriteLine($"=== {titulo} ===");
    }

    private void MostrarSucesso(string mensagem)
    {
        saida.WriteLine($"[OK] {mensagem}");
    }

    private void MostrarErro(string mensagem)
    {
        saida.WriteLine($"[ERRO] {mensagem} Voltando ao menu.");
    }
}
