using UrbanDrive.Models.Entities;

Console.WriteLine("=== CADASTRO DE VEICULOS VALIDOS ===");

Veiculo onix = new Veiculo(1, "ABC1D23", "Onix", 150);
Veiculo hb20 = new Veiculo(2, "XYZ9A87", "HB20", 140);
Veiculo kwid = new Veiculo(3, "QWE4R56", "Kwid", 120);

ExibirVeiculo(onix);
ExibirVeiculo(hb20);
ExibirVeiculo(kwid);

Console.WriteLine();
Console.WriteLine("=== TENTATIVA DE CADASTRO DE VEICULOS INVALIDOS ===");

TentarCriarVeiculo("Id zero", 0, "DEF5G67", "Mobi", 100);
TentarCriarVeiculo("Placa vazia", 4, "", "Mobi", 100);
TentarCriarVeiculo("Placa nula", 4, null!, "Mobi", 100);
TentarCriarVeiculo("Modelo so com espacos", 4, "DEF5G67", "   ", 100);
TentarCriarVeiculo("Diaria negativa", 4, "DEF5G67", "Mobi", -50);

Console.WriteLine();
Console.WriteLine("=== ALTERACAO DOS DADOS ===");

onix.ValorBaseDiaria = 200;
Console.WriteLine("Nova diaria do Onix: R$ " + onix.ValorBaseDiaria.ToString("F2"));

Console.WriteLine("Tentando alterar a placa do Onix para vazia...");

try
{
    onix.Placa = "";
}
catch (ArgumentException erro)
{
    Console.WriteLine("Erro: " + erro.Message);
}

Console.WriteLine("Placa mantida: " + onix.Placa);

Console.WriteLine();
Console.WriteLine("Demonstracao finalizada sem erros.");


static void ExibirVeiculo(Veiculo veiculo)
{
    Console.WriteLine("Id: " + veiculo.Id
        + " | Placa: " + veiculo.Placa
        + " | Modelo: " + veiculo.Modelo
        + " | Diaria: R$ " + veiculo.ValorBaseDiaria.ToString("F2"));
}

static void TentarCriarVeiculo(string descricao, int id, string placa, string modelo, double valorBaseDiaria)
{
    Console.WriteLine("Tentando cadastrar veiculo com " + descricao + "...");

    try
    {
        Veiculo veiculo = new Veiculo(id, placa, modelo, valorBaseDiaria);
        Console.WriteLine("Veiculo cadastrado: " + veiculo.Placa);
    }
    catch (ArgumentException erro)
    {
        Console.WriteLine("  Erro: " + erro.Message);
    }
}
