
namespace UrbanDrive.Models.Entities;

public class Veiculo
{
    private int id;
    private string placa;
    private string modelo;
    private double valorBaseDiaria;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Placa
    {
        get { return placa; }
        set { placa = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public double ValorBaseDiaria
    {
        get { return valorBaseDiaria; }
        set { valorBaseDiaria = value; }
    }

    public Veiculo(int id, string placa, string modelo, double valorBaseDiaria)
    {
        this.id = id;
        this.placa = placa;
        this.modelo = modelo;
        this.valorBaseDiaria = valorBaseDiaria;
    }
}
