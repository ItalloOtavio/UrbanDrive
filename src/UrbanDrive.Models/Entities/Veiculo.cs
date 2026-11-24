
using UrbanDrive.Models;
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
                throw new ArgumentOutOfRangeException(nameof(Id), "Id invalido! Deve ser maior que zero.");
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
                throw new ArgumentOutOfRangeException(nameof(ValorBaseDiaria), "Valor da diaria invalido! Deve ser maior que zero.");
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

        ConfiguradorSistema.RegistrarVeiculoCriado();
    }

      public virtual double CalcularAluguel(int dias)
    {
        if (dias <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dias), "A quantidade de dias deve ser maior que zero.");
        }

        return ValorBaseDiaria * dias;
    }

}
