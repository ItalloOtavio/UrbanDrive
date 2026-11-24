namespace UrbanDrive.Models.Entities
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; private set; }

        public Carro(int id, string placa, string modelo,
            double valorBaseDiaria, int quantidadePortas)
            : base(id, placa, modelo, valorBaseDiaria)
        {
            QuantidadePortas = quantidadePortas;
        }
    }
}