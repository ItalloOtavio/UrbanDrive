namespace UrbanDrive.Models.Entities;

public sealed class Patinete : Veiculo, IEletrico
{
    private int autonomiaBateria;
    private int nivelBateria = 100;

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

    public int NivelBateria
    {
        get { return nivelBateria; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(NivelBateria), "O nível da bateria deve estar entre 0 e 100.");
            }

            nivelBateria = value;
        }
    }

    public Patinete(int id, string placa, string modelo, double valorBaseDiaria, int autonomiaBateria)
        : base(id, placa, modelo, valorBaseDiaria)
    {
        AutonomiaBateria = autonomiaBateria;
    }

    public void Recarregar()
    {
        NivelBateria = 100;
    }

    public override double CalcularAluguel(int dias)
    {
        double total = base.CalcularAluguel(dias);

        if (dias >= 7)
        {
            total *= 0.90;
        }

        return total;
    }
}