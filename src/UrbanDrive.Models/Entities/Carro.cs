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

        public override double CalcularAluguel(int dias)
        {
            double valorDiarias = base.CalcularAluguel(dias);
            return valorDiarias + ConfiguradorSistema.TaxaSeguro * dias;
        }

        public override string GerarRelatorio()
        {
            return $"[Carro] {base.GerarRelatorio()} | Portas: {QuantidadePortas}";
        }
        
    }
}