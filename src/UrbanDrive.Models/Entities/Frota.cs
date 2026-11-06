
namespace UrbanDrive.Models.Entities;

public class Frota
{
    private List<Veiculo> veiculos = new List<Veiculo>();

    public bool AdicionarVeiculo(Veiculo veiculo)
    {
        for (int i = 0; i < veiculos.Count; i++)
        {
            if (veiculos[i].Placa == veiculo.Placa)
            {
                return false;
            }
        }

        veiculos.Add(veiculo);
        return true;
    }

    public bool RemoverVeiculo(string placa)
    {
        for (int i = 0; i < veiculos.Count; i++)
        {
            if (veiculos[i].Placa == placa)
            {
                veiculos.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public Veiculo? BuscarPorPlaca(string placa)
    {
        for (int i = 0; i < veiculos.Count; i++)
        {
            if (veiculos[i].Placa == placa)
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
}
