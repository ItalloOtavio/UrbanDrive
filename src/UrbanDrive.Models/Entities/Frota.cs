
namespace UrbanDrive.Models.Entities;

public class Frota : IImprimivel
{
    private List<Veiculo> veiculos = new List<Veiculo>();

    public string GerarRelatorio()
    {
        return $"Quantidade de veículos na frota: {veiculos.Count}";
    }

    public bool AdicionarVeiculo(Veiculo veiculo)
    {
        if (veiculo == null)
        {
            throw new ArgumentNullException(nameof(veiculo), "Veiculo obrigatorio!");
        }

        if (BuscarPorPlaca(veiculo.Placa) != null)
        {
            return false;
        }

        veiculos.Add(veiculo);
        return true;
    }

    public bool RemoverVeiculo(string placa)
    {
        Veiculo? veiculo = BuscarPorPlaca(placa);

        if (veiculo == null)
        {
            return false;
        }

        veiculos.Remove(veiculo);
        return true;
    }

    public Veiculo? BuscarPorPlaca(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
        {
            return null;
        }

        for (int i = 0; i < veiculos.Count; i++)
        {
            if (MesmaPlaca(veiculos[i].Placa, placa))
            {
                return veiculos[i];
            }
        }

        return null;
    }

    public List<Veiculo> ListarVeiculos()
    {
        return new List<Veiculo>(veiculos);
    }

    // Placas iguais sem diferenciar maiusculas/minusculas nem espacos nas pontas
    // ("abc1d23" e "ABC1D23 " sao a mesma placa).
    private static bool MesmaPlaca(string placaA, string placaB)
    {
        return string.Equals(placaA.Trim(), placaB.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
