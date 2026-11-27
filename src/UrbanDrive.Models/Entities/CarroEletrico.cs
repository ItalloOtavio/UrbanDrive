namespace UrbanDrive.Models.Entities;

public class CarroEletrico : Carro, IEletrico
{
    private int nivelBateria;

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

    public CarroEletrico(int id, string placa, string modelo, double valorBaseDiaria, int quantidadePortas, int nivelBateria)
        : base(id, placa, modelo, valorBaseDiaria, quantidadePortas)
    {
        NivelBateria = nivelBateria;
    }

    public void Recarregar()
    {
        NivelBateria = 100;
    }
}