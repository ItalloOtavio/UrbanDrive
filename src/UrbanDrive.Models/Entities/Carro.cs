namespace UrbanDrive.Models.Entities
{
    public class Carro : Veiculo
    {
        private int quantidadePortas;

        public int QuantidadePortas
        {
            get { return quantidadePortas; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(QuantidadePortas), "Quantidade de portas invalida! Deve ser maior que zero.");
                }

                quantidadePortas = value;
            }
        }

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