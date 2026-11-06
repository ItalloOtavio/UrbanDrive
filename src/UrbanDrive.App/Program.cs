using System;
using UrbanDrive.Models;
using UrbanDrive.Models.Entities;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("==================================================");
Console.WriteLine("        URBANDRIVE - DEMONSTRADOR SPRINT 2        ");
Console.WriteLine("==================================================");
Console.ResetColor();

// 1. Motorista com CNH (Composicao)
Console.WriteLine("\n=== [1] MOTORISTA E CNH (COMPOSIÇÃO) ===");
DateTime validadeFutura = DateTime.Today.AddYears(4);
Motorista motorista = new Motorista(
    "Wagner Junior",
    "123.456.789-00",
    "98765432100",
    "B",
    validadeFutura
);

Console.WriteLine($"Motorista: {motorista.Nome} | CPF: {motorista.CPF}");
Console.WriteLine($"CNH vinculada: N.º {motorista.Habilitacao.Numero} | Categoria: {motorista.Habilitacao.Categoria} | Validade: {motorista.Habilitacao.DataValidade:dd/MM/yyyy} (Válida: {motorista.Habilitacao.EstaValida()})");

// 2. Veiculos e Frota (Agregacao)
Console.WriteLine("\n=== [2] VEÍCULOS E FROTA (AGREGAÇÃO) ===");
Veiculo onix = new Veiculo(1, "ABC1D23", "Onix", 150);
ConfiguradorSistema.RegistrarVeiculoCriado();

Veiculo hb20 = new Veiculo(2, "XYZ9A87", "HB20", 140);
ConfiguradorSistema.RegistrarVeiculoCriado();

Veiculo kwid = new Veiculo(3, "QWE4R56", "Kwid", 120);
ConfiguradorSistema.RegistrarVeiculoCriado();

Frota frota = new Frota();
frota.AdicionarVeiculo(onix);
frota.AdicionarVeiculo(hb20);
frota.AdicionarVeiculo(kwid);

var veiculosDaFrota = frota.ListarVeiculos();
Console.WriteLine($"Total de veículos gerenciados na frota: {veiculosDaFrota.Count}");
foreach (var v in veiculosDaFrota)
{
    Console.WriteLine($"  - [ID {v.Id}] {v.Modelo} | Placa: {v.Placa} | Diária: R$ {v.ValorBaseDiaria:F2}");
}

// 3. Membros Estáticos (ConfiguradorSistema)
Console.WriteLine("\n=== [3] MEMBROS ESTÁTICOS (CONFIGURADORSISTEMA) ===");
ConfiguradorSistema.TaxaSeguro = 25.00;
Console.WriteLine($"Total de veículos registrados globalmente: {ConfiguradorSistema.TotalVeiculosCriados}");
Console.WriteLine($"Taxa de seguro configurada no sistema: R$ {ConfiguradorSistema.TaxaSeguro:F2}");

// 4. Locacao sendo criada (Associacao)
Console.WriteLine("\n=== [4] CRIAÇÃO DE LOCAÇÃO (ASSOCIAÇÃO) ===");
int diasLocacao = 5;
Locacao locacao = new Locacao(motorista, onix, diasLocacao);

double custoDiarias = locacao.Dias * locacao.Veiculo.ValorBaseDiaria;
double custoTotal = custoDiarias + (ConfiguradorSistema.TaxaSeguro * locacao.Dias);

Console.WriteLine($"Locação criada com sucesso!");
Console.WriteLine($"Motorista: {locacao.Motorista.Nome} (CNH: {locacao.Motorista.Habilitacao.Numero})");
Console.WriteLine($"Veículo alugado: {locacao.Veiculo.Modelo} (Placa: {locacao.Veiculo.Placa})");
Console.WriteLine($"Período: {locacao.Dias} dias");
Console.WriteLine($"Subtotal diárias: R$ {custoDiarias:F2}");
Console.WriteLine($"Total com seguro do sistema: R$ {custoTotal:F2}");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nDemonstração da Sprint 2 finalizada com sucesso!");
Console.ResetColor();