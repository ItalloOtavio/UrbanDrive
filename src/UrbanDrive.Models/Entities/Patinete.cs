namespace UrbanDrive.Models.Entities;

public sealed class Patinete : Veiculo
{
    private int autonomiaBateria;

    public int AutonomiaBateria
    {
        get { return autonomiaBateria; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(AutonomiaBateria), "Autonomia da bateria invalida! Deve ser maior que zero.");
            }

            autonomiaBateria = value;
        }
    }

    public Patinete(int id, string placa, string modelo, double valorBaseDiaria, int autonomiaBateria)
        : base(id, placa, modelo, valorBaseDiaria)
    {
        AutonomiaBateria = autonomiaBateria;
    }
}
