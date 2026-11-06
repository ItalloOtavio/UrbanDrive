
namespace UrbanDrive.Models;

public static class ConfiguradorSistema
{
    private static double taxaSeguro = 0;
    private static int contadorVeiculos = 0;

    public static double TaxaSeguro
    {
        get { return taxaSeguro; }

        set
        {
            if (value >= 0)
            {
                taxaSeguro = value;
            }
        }
    }

    public static int TotalVeiculosCriados
    {
        get { return contadorVeiculos; }
    }

    public static void RegistrarVeiculoCriado()
    {
        contadorVeiculos++;
    }
}
