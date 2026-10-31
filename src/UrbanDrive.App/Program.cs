using UrbanDrive.Models.Entities;

Veiculo veiculo = new Veiculo(1, "ABC1D23", "Onix", 150);

Console.WriteLine("=== CADASTRO DO VEICULO ===");
Console.WriteLine("Id: " + veiculo.Id);
Console.WriteLine("Placa: " + veiculo.Placa);
Console.WriteLine("Modelo: " + veiculo.Modelo);
Console.WriteLine("Diaria: R$ " + veiculo.ValorBaseDiaria.ToString("F2"));

Console.WriteLine();
Console.WriteLine("=== ALTERACAO DA DIARIA ===");

veiculo.ValorBaseDiaria = 200;

Console.WriteLine("Nova diaria: R$ " + veiculo.ValorBaseDiaria.ToString("F2"));

Console.WriteLine();
Console.WriteLine("=== VALIDACAO DA PLACA ===");
Console.WriteLine("Tentando cadastrar uma placa vazia...");

try
{
    veiculo.Placa = "";
}
catch (ArgumentException erro)
{
    Console.WriteLine("Erro: " + erro.Message);
}

Console.WriteLine("Placa mantida: " + veiculo.Placa);