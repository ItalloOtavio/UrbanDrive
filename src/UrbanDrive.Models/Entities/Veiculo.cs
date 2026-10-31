
namespace UrbanDrive.Models.Entities;

public class Veiculo
{

    private int id;
    private string placa = "";
    private string modelo = "";
    private double valorBaseDiaria;


    public int Id
    {
        get { return id; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Id invalido!");
            }

            id = value;
        }
    }


    
    public string Placa
    {
        get { return placa; }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Placa invalida!");
            }

            placa = value;
        }
    }



    public string Modelo
    {
        get { return modelo; }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Modelo invalido!");
            }

            modelo = value;
        }
    }



    public double ValorBaseDiaria
    {
        get { return valorBaseDiaria; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Valor da diaria invalido!");
            }

            valorBaseDiaria = value;
        }
    }



    public Veiculo(int id, string placa, string modelo, double valorBaseDiaria)
    {
        Id = id;
        Placa = placa;
        Modelo = modelo;
        ValorBaseDiaria = valorBaseDiaria;
    }

}
